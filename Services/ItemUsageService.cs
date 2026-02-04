using InventorySystem.Core.Interfaces;
using InventorySystem.Strategies;

namespace InventorySystem.Services;

/// <summary>
/// Сервис для использования предметов.
/// Принцип Single Responsibility: отвечает только за логику использования предметов.
/// Принцип Dependency Inversion: зависит от интерфейсов IUsable и IEquippable, а не от конкретных классов.
/// 
/// РАСШИРЕНИЕ: Теперь поддерживает паттерн Strategy для использования предметов.
/// Это позволяет использовать один предмет разными способами в зависимости от контекста.
/// </summary>
public class ItemUsageService
{
    private readonly Inventory _inventory;
    private IItemUsageStrategy? _defaultUsageStrategy;

    public ItemUsageService(Inventory inventory)
    {
        _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        _defaultUsageStrategy = new ConsumeUsageStrategy(); // Стратегия по умолчанию
    }

    /// <summary>
    /// Установить стратегию использования по умолчанию
    /// </summary>
    public void SetDefaultUsageStrategy(IItemUsageStrategy strategy)
    {
        _defaultUsageStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    /// <summary>
    /// Использовать предмет (зелье, еда и т.д.)
    /// Использует стратегию по умолчанию или стандартное поведение через интерфейс IUsable.
    /// </summary>
    public UseResult UseItem(string itemId)
    {
        return UseItem(itemId, _defaultUsageStrategy);
    }

    /// <summary>
    /// Использовать предмет с указанной стратегией
    /// </summary>
    public UseResult UseItem(string itemId, IItemUsageStrategy? strategy)
    {
        var item = _inventory.FindItemById(itemId);
        if (item == null)
        {
            return new UseResult
            {
                Success = false,
                Message = $"Item with ID {itemId} not found in inventory"
            };
        }

        // Если указана стратегия, используем её
        if (strategy != null && strategy.CanUse(item))
        {
            var result = strategy.Use(item);
            
            // Если предмет одноразовый и был использован, удаляем его из инвентаря
            if (result.Success && ShouldRemoveAfterUse(item))
            {
                _inventory.RemoveItem(item);
            }

            return result;
        }

        // Иначе используем стандартное поведение через интерфейс IUsable
        if (item is not IUsable usableItem)
        {
            return new UseResult
            {
                Success = false,
                Message = $"{item.Name} cannot be used"
            };
        }

        var standardResult = usableItem.Use();
        
        // Если предмет одноразовый и был использован, удаляем его из инвентаря
        if (standardResult.Success && ShouldRemoveAfterUse(item))
        {
            _inventory.RemoveItem(item);
        }

        return standardResult;
    }

    /// <summary>
    /// Экипировать предмет
    /// </summary>
    public bool EquipItem(string itemId)
    {
        var item = _inventory.FindItemById(itemId);
        if (item == null)
        {
            return false;
        }

        if (item is not IEquippable equippableItem)
        {
            return false;
        }

        // Validate equipping logic without exceptions
        if (equippableItem.Slot == EquipmentSlot.Weapon)
        {
            var equippedWeapons = GetEquippedWeapons().Count();
            if (equippedWeapons >= 2 && !equippableItem.IsEquipped)
            {
                return false;
            }

            if (equippableItem.IsEquipped)
            {
                return true;
            }
        }
        else
        {
            UnequipItemsInSlot(equippableItem.Slot);
        }

        equippableItem.Equip();
        return true;
    }

    /// <summary>
    /// Снять предмет
    /// </summary>
    public bool UnequipItem(string itemId)
    {
        var item = _inventory.FindItemById(itemId);
        if (item == null)
        {
            return false;
        }

        if (item is not IEquippable equippableItem)
        {
            return false;
        }

        equippableItem.Unequip();
        return true;
    }

    /// <summary>
    /// Снять все предметы из указанного слота
    /// </summary>
    private void UnequipItemsInSlot(EquipmentSlot slot)
    {
        var itemsInSlot = _inventory.Items
            .OfType<IEquippable>()
            .Where(item => item.Slot == slot && item.IsEquipped);

        foreach (var item in itemsInSlot)
        {
            item.Unequip();
        }
    }

    /// <summary>
    /// Проверить, нужно ли удалить предмет после использования
    /// </summary>
    private bool ShouldRemoveAfterUse(IItem item)
    {
        // Еда удаляется после использования
        if (item is Core.Items.Food food && food.IsConsumed)
        {
            return true;
        }

        // Зелья с нулевыми зарядами можно удалить (но это опционально)
        // Для этой лабораторной оставим зелья в инвентаре даже с 0 зарядами

        return false;
    }

    /// <summary>
    /// Получить все экипированные предметы
    /// </summary>
    public IEnumerable<IEquippable> GetEquippedItems()
    {
        return _inventory.Items
            .OfType<IEquippable>()
            .Where(item => item.IsEquipped);
    }

    /// <summary>
    /// Получить все экипированное оружие
    /// </summary>
    private IEnumerable<IEquippable> GetEquippedWeapons()
    {
        return _inventory.Items
            .OfType<IEquippable>()
            .Where(item => item.IsEquipped && item.Slot == EquipmentSlot.Weapon);
    }
}

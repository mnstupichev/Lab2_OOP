using InventorySystem.Core.Interfaces;
using InventorySystem.Strategies;

namespace InventorySystem.Services;

public class ItemUsageService
{
    private readonly Inventory _inventory;
    private IItemUsageStrategy? _defaultUsageStrategy;

    public ItemUsageService(Inventory inventory)
    {
        _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        _defaultUsageStrategy = new ConsumeUsageStrategy();
    }

    public void SetDefaultUsageStrategy(IItemUsageStrategy strategy)
    {
        _defaultUsageStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public UseResult UseItem(string itemId)
    {
        return UseItem(itemId, _defaultUsageStrategy);
    }

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

        if (strategy != null && strategy.CanUse(item))
        {
            var result = strategy.Use(item);
            if (result.Success && ShouldRemoveAfterUse(item))
            {
                _inventory.RemoveItem(item);
            }

            return result;
        }

        if (item is not IUsable usableItem)
        {
            return new UseResult
            {
                Success = false,
                Message = $"{item.Name} cannot be used"
            };
        }

        var standardResult = usableItem.Use();

        if (standardResult.Success && ShouldRemoveAfterUse(item))
        {
            _inventory.RemoveItem(item);
        }

        return standardResult;
    }

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

    private bool ShouldRemoveAfterUse(IItem item)
    {

        if (item is Core.Items.Food food && food.IsConsumed)
        {
            return true;
        }


        return false;
    }

    public IEnumerable<IEquippable> GetEquippedItems()
    {
        return _inventory.Items
            .OfType<IEquippable>()
            .Where(item => item.IsEquipped);
    }

    private IEnumerable<IEquippable> GetEquippedWeapons()
    {
        return _inventory.Items
            .OfType<IEquippable>()
            .Where(item => item.IsEquipped && item.Slot == EquipmentSlot.Weapon);
    }
}

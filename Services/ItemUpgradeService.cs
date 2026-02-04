using InventorySystem.Core.Interfaces;
using InventorySystem.Core.States;

namespace InventorySystem.Services;

/// <summary>
/// Сервис для улучшения предметов.
/// Принцип Single Responsibility: отвечает только за логику улучшения предметов.
/// </summary>
public class ItemUpgradeService
{
    private readonly Inventory _inventory;
    private readonly double _upgradeModifier;

    public ItemUpgradeService(Inventory inventory, double upgradeModifier = 1.5)
    {
        _inventory = inventory ?? new Inventory();
        _upgradeModifier = upgradeModifier;
    }

    /// <summary>
    /// Улучшить предмет по ID
    /// </summary>
    public UpgradeResult UpgradeItem(string itemId)
    {
        var item = _inventory.FindItemById(itemId);
        if (item == null)
        {
            return new UpgradeResult
            {
                Success = false,
            };
        }

        return UpgradeItem(item);
    }

    /// <summary>
    /// Улучшить предмет напрямую
    /// </summary>
    public UpgradeResult UpgradeItem(IItem item)
    {
        if (item == null)
        {
            return new UpgradeResult
            {
                Success = false,
            };
        }

        // Проверяем, можно ли улучшить предмет
        if (item.State is UpgradedItemState)
        {
            return new UpgradeResult
            {
                Success = false,
            };
        }

        if (item.State is BrokenItemState)
        {
            return new UpgradeResult
            {
                Success = false,
            };
        }

        // Создаем улучшенное состояние
        var upgradedState = new UpgradedItemState(_upgradeModifier);
        item.State = upgradedState;

        return new UpgradeResult
        {
            Success = true,
            UpgradedItem = item,
            Changes = new Dictionary<string, object>
            {
                { "Modifier", _upgradeModifier },
                { "State", "Upgraded" }
            }
        };
    }
}

/// <summary>
/// Результат улучшения предмета
/// </summary>
public class UpgradeResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public IItem? UpgradedItem { get; set; }
    public Dictionary<string, object> Changes { get; set; } = new();
}

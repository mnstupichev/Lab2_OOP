using InventorySystem.Core.Interfaces;

namespace InventorySystem.Strategies;

/// <summary>
/// Стратегия использования: экипировка предмета (оружие, броня, аксессуары).
/// Используется для предметов, которые экипируются на персонажа.
/// </summary>
public class EquipUsageStrategy : IItemUsageStrategy
{
    public string StrategyName => "Equip";

    public bool CanUse(IItem item)
    {
        if (item is not IEquippable equippable)
            return false;

        // Проверяем состояние предмета
        if (item.State?.CanEquip == false)
            return false;

        return true;
    }

    public UseResult Use(IItem item)
    {
        if (item is not IEquippable equippable)
        {
            return new UseResult
            {
                Success = false,
                Message = $"{item.Name} cannot be equipped"
            };
        }

        if (!equippable.CanEquip())
        {
            return new UseResult
            {
                Success = false,
                Message = $"{item.Name} cannot be equipped due to its state"
            };
        }

        equippable.Equip();
        return new UseResult
        {
            Success = true,
            Message = $"{item.Name} has been equipped",
            Effects = new Dictionary<string, object>
            {
                { "Equipped", true },
                { "Slot", equippable.Slot.ToString() }
            }
        };
    }
}

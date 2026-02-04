using InventorySystem.Core.Interfaces;

namespace InventorySystem.Strategies;

public class EquipUsageStrategy : IItemUsageStrategy
{
    public string StrategyName => "Equip";

    public bool CanUse(IItem item)
    {
        if (item is not IEquippable equippable)
            return false;

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
            };
        }

        equippable.Equip();
        return new UseResult
        {
            Success = true,
            Effects = new Dictionary<string, object>
            {
                { "Equipped", true },
                { "Slot", equippable.Slot.ToString() }
            }
        };
    }
}

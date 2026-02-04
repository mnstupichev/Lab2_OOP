using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Strategies;

public class ConsumeUsageStrategy : IItemUsageStrategy
{
    public string StrategyName => "Consume";

    public bool CanUse(IItem item)
    {
        return item is IUsable usable && usable.CanUse;
    }

    public UseResult Use(IItem item)
    {
        if (item is not IUsable usable)
        {
            return new UseResult
            {
                Success = false,
            };
        }

        return usable.Use();
    }
}

using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Strategies;

public class ThrowUsageStrategy : IItemUsageStrategy
{
    public string StrategyName => "Throw";

    public bool CanUse(IItem item)
    {
        return item is Potion potion && potion.Quatity > 0;
    }

    public UseResult Use(IItem item)
    {
        if (item is not Potion potion)
        {
            return new UseResult
            {
                Success = false,
            };
        }

        if (potion.Quatity <= 0)
        {
            return new UseResult
            {
                Success = false,
            };
        }

        potion.Quantity--;
        var damage = potion.Potency / 2;

        return new UseResult
        {
            Success = true,
            Effects = new Dictionary<string, object>
            {
                { "Damage", damage },
                { "EffectType", potion.Effect.ToString() },
                { "RemainingCharges", potion.Quatity }
            }
        };
    }
}

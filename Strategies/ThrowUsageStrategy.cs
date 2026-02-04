using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Strategies;

/// <summary>
/// Стратегия использования: бросить предмет (например, зелье можно бросить во врага).
/// Демонстрирует, как один предмет (зелье) может использоваться по-разному.
/// </summary>
public class ThrowUsageStrategy : IItemUsageStrategy
{
    public string StrategyName => "Throw";

    public bool CanUse(IItem item)
    {
        // Можно бросать зелья и некоторые другие предметы
        return item is Potion potion && potion.Quatity > 0;
    }

    public UseResult Use(IItem item)
    {
        if (item is not Potion potion)
        {
            return new UseResult
            {
                Success = false,
                Message = $"{item.Name} cannot be thrown"
            };
        }

        if (potion.Quatity <= 0)
        {
            return new UseResult
            {
                Success = false,
                Message = $"{item.Name} has no charges to throw"
            };
        }

        potion.Charges--; // Уменьшаем заряды

        // При броске зелье наносит урон вместо восстановления здоровья
        var damage = potion.Potency / 2; // Урон равен половине силы зелья

        return new UseResult
        {
            Success = true,
            Message = $"Threw {item.Name} at enemy, dealing {damage} damage",
            Effects = new Dictionary<string, object>
            {
                { "Damage", damage },
                { "EffectType", potion.Effect.ToString() },
                { "RemainingCharges", potion.Quatity }
            }
        };
    }
}

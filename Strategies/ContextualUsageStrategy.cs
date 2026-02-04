using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Strategies;

public class ContextualUsageStrategy : IItemUsageStrategy
{
    private readonly bool _isAttackMode;

    public ContextualUsageStrategy(bool isAttackMode = false)
    {
        _isAttackMode = isAttackMode;
    }

    public string StrategyName => _isAttackMode ? "Attack" : "Utility";

    public bool CanUse(IItem item)
    {
        if (_isAttackMode)
        {
            return item is Weapon || item is Potion;
        }
        else
        {
            return item is Weapon || item is Potion || item is Block;
        }
    }

    public UseResult Use(IItem item)
    {
        if (_isAttackMode)
        {
            return UseInAttackMode(item);
        }
        else
        {
            return UseInUtilityMode(item);
        }
    }

    private UseResult UseInAttackMode(IItem item)
    {
        if (item is Weapon weapon)
        {
            var modifier = item.State?.StatModifier ?? 1.0;
            var damage = (int)(weapon.BaseDamage * modifier);
            
            return new UseResult
            {
                Success = true,
                Message = $"Attacked with {weapon.Name}, dealing {damage} damage",
                Effects = new Dictionary<string, object>
                {
                    { "Damage", damage },
                    { "DamageType", weapon.DamageType.ToString() },
                    { "Mode", "Attack" }
                }
            };
        }

        if (item is Potion potion && potion.CanUse)
        {
            potion.Quantity--;
            var damage = potion.Potency / 2;
            
            return new UseResult
            {
                Success = true,
                Message = $"Threw {potion.Name} at enemy, dealing {damage} damage",
                Effects = new Dictionary<string, object>
                {
                    { "Damage", damage },
                    { "EffectType", potion.Effect.ToString() },
                    { "Mode", "Attack" }
                }
            };
        }

        return new UseResult
        {
            Success = false,
            Message = $"{item.Name} cannot be used in attack mode"
        };
    }

    private UseResult UseInUtilityMode(IItem item)
    {
        if (item is Weapon weapon)
        {
            var utilityAction = GetUtilityAction(weapon);
            var modifier = item.State?.StatModifier ?? 1.0;
            var efficiency = (int)(weapon.BaseDamage * modifier * 0.5);
            
            return new UseResult
            {
                Success = true,
                Message = $"Used {weapon.Name} to {utilityAction}, efficiency: {efficiency}",
                Effects = new Dictionary<string, object>
                {
                    { "Action", utilityAction },
                    { "Efficiency", efficiency },
                    { "Mode", "Utility" }
                }
            };
        }

        if (item is Potion potion && potion.CanUse)
        {
            potion.Quantity--;
            var modifier = item.State?.StatModifier ?? 1.0;
            var effectivePotency = (int)(potion.Potency * modifier * 1.2);
            
            return new UseResult
            {
                Success = true,
                Message = $"Used {potion.Name} carefully. Enhanced effect: {effectivePotency}",
                Effects = new Dictionary<string, object>
                {
                    { "Effect", potion.Effect.ToString() },
                    { "Potency", effectivePotency },
                    { "Mode", "Utility" }
                }
            };
        }

        if (item is Block block && block.CanUse)
        {
            return block.Use();
        }

        return new UseResult
        {
            Success = false,
            Message = $"{item.Name} cannot be used in utility mode"
        };
    }

    private string GetUtilityAction(Weapon weapon)
    {
        return weapon.Name.ToLower() switch
        {
            var name when name.Contains("pickaxe") || name.Contains("pick") => "mine blocks",
            var name when name.Contains("axe") => "chop trees",
            var name when name.Contains("shovel") || name.Contains("spade") => "dig dirt",
            var name when name.Contains("hoe") => "till soil",
            var name when name.Contains("sword") => "cut vegetation",
            _ => "perform utility action"
        };
    }
}

using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Strategies;

/// <summary>
/// Контекстная стратегия использования: поведение зависит от контекста (в бою/вне боя).
/// Демонстрирует, как один предмет может работать по-разному в разных ситуациях.
/// </summary>
public class ContextualUsageStrategy : IItemUsageStrategy
{
    private readonly bool _isInCombat;

    public ContextualUsageStrategy(bool isInCombat = false)
    {
        _isInCombat = isInCombat;
    }

    public string StrategyName => _isInCombat ? "UseInCombat" : "UseOutOfCombat";

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

        var baseResult = usable.Use();

        if (!baseResult.Success)
            return baseResult;

        // Модифицируем результат в зависимости от контекста
        if (item is Potion potion)
        {
            var modifier = _isInCombat ? 0.7 : 1.2; // В бою меньше эффект, вне боя больше
            var originalPotency = (int)baseResult.Effects["Potency"];
            var modifiedPotency = (int)(originalPotency * modifier);

            return new UseResult
            {
                Success = true,
                Message = _isInCombat 
                    ? $"{item.Name} used in combat. Quick effect: {modifiedPotency} (reduced)"
                    : $"{item.Name} used safely. Full effect: {modifiedPotency} (enhanced)",
                Effects = new Dictionary<string, object>(baseResult.Effects)
                {
                    ["Potency"] = modifiedPotency,
                    ["Context"] = _isInCombat ? "Combat" : "Safe"
                }
            };
        }

        return baseResult;
    }
}

using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

/// <summary>
/// Класс еды.
/// Реализует IUsable для возможности использования.
/// </summary>
public class Food : BaseItem, IUsable
{
    public int HealthRestoration { get; private set; }
    public int StaminaRestoration { get; private set; }
    public bool IsConsumed { get; private set; }

    public Food(
        string id,
        string name,
        string description,
        int quantity,
        int healthRestoration)
        : base(id, name, description, quantity)
    {
        HealthRestoration = healthRestoration;
        IsConsumed = false;
    }

    public bool CanUse => !IsConsumed && (State?.CanUse ?? true);

    public UseResult Use()
    {
        if (!CanUse)
        {
            return new UseResult
            {
                Success = false,
            };
        }

        IsConsumed = true;
        var modifier = State?.StatModifier ?? 1.0;
        var effectiveHealth = (int)(HealthRestoration * modifier);

        return new UseResult
        {
            Success = true,
            Effects = new Dictionary<string, object>
            {
                { "HealthRestoration", effectiveHealth }
            }
        };
    }
}

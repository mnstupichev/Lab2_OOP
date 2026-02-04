using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

public class Food : BaseItem, IUsable
{
    public int HealthRestoration { get; private set; }
    public int StaminaRestoration { get; private set; }
    public bool IsConsumed { get; private set; }

    public Food(
        string name,
        int quantity,
        int healthRestoration)
        : base(name, quantity)
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
        var effectiveHealth = (int)(HealthRestoration);

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

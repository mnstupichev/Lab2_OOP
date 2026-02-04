using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

public class Potion : BaseItem, IUsable
{
    public PotionEffect Effect { get; private set; }
    public int Potency { get; private set; }
    public int Quatity { get; private set; }

    public Potion(
        string name,
        int quantity,
        PotionEffect effect,
        int potency)
        : base(name, quantity)
    {
        Effect = effect;
        Potency = potency;
        Quatity = quantity;
    }

    public bool CanUse => Quatity > 0 && (State?.CanUse ?? true);

    public UseResult Use()
    {
        if (!CanUse)
        {
            return new UseResult
            {
                Success = false,
            };
        }

        Quatity--;
        var effectivePotency = (int)(Potency);

        return new UseResult
        {
            Success = true,
            Effects = new Dictionary<string, object>
            {
                { "Effect", Effect.ToString() },
                { "Potency", effectivePotency }
            }
        };
    }
}

public enum PotionEffect
{
    Health,
    FireProtection,
    Strength,
    Speed,
    Invisibility
}

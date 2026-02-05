using InventorySystem.Interfaces;

namespace InventorySystem.Items;

public class Potion : BaseItem, IUsable
{
    public PotionEffect Effect { get; private set; }
    public int Potency { get; private set; }

    public Potion(
        string name,
        int quantity,
        PotionEffect effect,
        int potency)
        : base(name, quantity)
    {
        Effect = effect;
        Potency = potency;
    }

    public bool CanUse => Quantity > 0;

    public UseResult Use()
    {
        if (!CanUse)
        {
            return new UseResult 
            {
                Success = false,
            };
        }

        Quantity--;

        return new UseResult
        {
            Success = true,
        };
    }
}

using InventorySystem.Interfaces;

namespace InventorySystem.Items;

public class Food : BaseItem, IUsable
{
    public int HealthRestoration { get; private set; }
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

    public bool CanUse => !IsConsumed;

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
        Quantity--;

        return new UseResult
        {
            Success = true,
        };
    }
}

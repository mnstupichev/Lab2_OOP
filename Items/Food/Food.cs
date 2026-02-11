using InventorySystem.Services.UseServise;

namespace InventorySystem.Items.Food;

public class Food : BaseItem.BaseItem, IUsable
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
    
    public UseResult Use()
    {
        if (Quantity == 0)
        {
            return new UseResult.Failure();
        }

        IsConsumed = true;
        Quantity--;
        return new UseResult.Success();
    }
}

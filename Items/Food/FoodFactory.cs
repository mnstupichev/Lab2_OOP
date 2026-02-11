using InventorySystem.Items.BaseItem;

namespace InventorySystem.Items.Food;

public class FoodFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new FoodBuilder().Build();
    }
}

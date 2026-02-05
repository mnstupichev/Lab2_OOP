using InventorySystem.Builders;
using InventorySystem.Interfaces;

namespace InventorySystem.Factories;

public class FoodFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new FoodBuilder().Build();
    }
}

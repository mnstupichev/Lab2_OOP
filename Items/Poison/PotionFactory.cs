using InventorySystem.Builders;
using InventorySystem.Interfaces;

namespace InventorySystem.Factories;

public class PotionFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new PotionBuilder().Build();
    }
}

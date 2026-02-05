using InventorySystem.Interfaces;
using InventorySystem.Items;

namespace InventorySystem.Factories;

public class ArmorFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new ArmorBuilder().Build();
    }
}

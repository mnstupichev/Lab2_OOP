using InventorySystem.Builders;
using InventorySystem.Interfaces;
using InventorySystem.Items;

namespace InventorySystem.Factories;

public class WeaponFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new WeaponBuilder().Build();
    }
}

using InventorySystem.Items.BaseItem;

namespace InventorySystem.Items.Weapon;

public class WeaponFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new WeaponBuilder().Build();
    }
}

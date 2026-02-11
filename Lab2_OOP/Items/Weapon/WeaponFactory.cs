using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.Items.Weapon;

public class WeaponFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new WeaponBuilder().Build();
    }
}

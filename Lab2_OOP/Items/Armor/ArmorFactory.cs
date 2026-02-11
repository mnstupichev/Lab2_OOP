using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.Items.Armor;

public class ArmorFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new ArmorBuilder().Build();
    }
}

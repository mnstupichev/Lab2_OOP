using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.Items.Poison;

public class PotionFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new PotionBuilder().Build();
    }
}

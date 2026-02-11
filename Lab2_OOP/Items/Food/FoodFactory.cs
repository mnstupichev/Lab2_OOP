using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.Items.Food;

public class FoodFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new FoodBuilder().Build();
    }
}

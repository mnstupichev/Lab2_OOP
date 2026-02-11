using InventorySystem.Items.BaseItem;

namespace InventorySystem.Items.Poison;

public class PotionFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new PotionBuilder().Build();
    }
}

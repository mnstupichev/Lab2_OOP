using InventorySystem.Items.BaseItem;

namespace InventorySystem.Items.Armor;

public class ArmorFactory : IItemFactory
{
    public IItem CreateItem()
    {
        return new ArmorBuilder().Build();
    }
}

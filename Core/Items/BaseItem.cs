using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

public abstract class BaseItem : IItem
{
    public string Name { get; protected set; }
    public int Quantity { get; set; }

    public IItemState? State { get; set; }

    protected BaseItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}

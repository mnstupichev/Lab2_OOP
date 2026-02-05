using InventorySystem.Interfaces;

namespace InventorySystem.Items;

public abstract class BaseItem : IItem
{
    public string Name { get; }
    public int Quantity { get; set; }

    protected BaseItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}

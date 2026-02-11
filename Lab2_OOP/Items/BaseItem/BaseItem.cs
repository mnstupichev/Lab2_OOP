namespace InventorySystem.Items.BaseItem;

public abstract class BaseItem : IItem
{
    public string Name { get; }
    public int Quantity { get; protected set; }

    protected BaseItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}

namespace InventorySystem.Items.BaseItem;

public interface IItem
{
    string Name { get; }
    int Quantity { get; }
}

namespace InventorySystem.Core.Interfaces;

public interface IItem
{
    string Name { get; }
    int Quantity { get; }
    IItemState? State { get; set; }
}

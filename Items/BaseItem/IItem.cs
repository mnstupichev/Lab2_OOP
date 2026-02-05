namespace InventorySystem.Interfaces;

public interface IItem
{
    string Name { get; }
    int Quantity { get; set; }
}

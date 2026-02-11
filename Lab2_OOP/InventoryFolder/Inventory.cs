using InventorySystem.InventoryFolder.InventoryStates;
using InventorySystem.InventoryFolder.Results;
using InventorySystem.Items.BaseItem;

namespace InventorySystem.InventoryFolder;

public class Inventory : IInventory
{
    private readonly List<IItem> _items;
    public int MaxQuantity { get; }
    private IInventoryState _state;

    public Inventory(int maxQuantity = 100)
    {
        _items = new List<IItem>();
        MaxQuantity = maxQuantity;
        _state = new NormalInventoryState();
    }

    public int CurrentQuantity => _items.Sum(item => item.Quantity);
    public IInventoryState State => _state;
    public IReadOnlyList<IItem> Items => _items.AsReadOnly();

    public AddItemResult TryAddItem(IItem item)
    {
        return _state.TryAddItem(this, item);
    }

    public RemoveResult TryRemoveItem(IItem item)
    {
        return _state.TryRemoveItem(this, item);
    }

    public void AddItem(IItem item)
    {
        _items.Add(item);
    }
    
    public void RemoveItem(IItem item)
    {
        _items.Remove(item);
    }

    public void ChangeState(IInventoryState state)
    {
        _state = state;
    }
}

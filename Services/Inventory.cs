using InventorySystem.Core.Interfaces;
using InventorySystem.Core.States;

namespace InventorySystem.Services;

public class Inventory
{
    private readonly List<IItem> _items;
    private readonly int _maxQuantity;
    private IInventoryState _state;

    public Inventory(int maxQuantity = 100)
    {
        _items = new List<IItem>();
        _maxQuantity = maxQuantity;
        _state = new NormalInventoryState();
    }

    public int CurrentQuantity => _items.Sum(item => item.Quantity);

    public int MaxQuantity => _maxQuantity;

    public IInventoryState State => _state;

    public IReadOnlyList<IItem> Items => _items.AsReadOnly();

    public bool AddItem(IItem item)
    {
        if (item == null)
            return false;

        if (!_state.CanAddItem(item, CurrentQuantity, _maxQuantity))
        {
            UpdateState();
            return false;
        }

        _items.Add(item);
        UpdateState();
        return true;
    }

    public bool RemoveItem(IItem item)
    {
        if (item == null)
            return false;

        if (!_state.CanRemoveItem())
        {
            return false;
        }

        var removed = _items.Remove(item);
        if (removed)
        {
            UpdateState();
        }
        return removed;
    }

    public IItem? FindItemById(string id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public IEnumerable<T> FindItemsByType<T>() where T : class, IItem
    {
        return _items.OfType<T>();
    }

    private void UpdateState()
    {
        var newState = _state.Transition(CurrentQuantity, _maxQuantity);
        if (newState != null)
        {
            _state = newState;
        }
    }
}

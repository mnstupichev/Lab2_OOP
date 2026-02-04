using InventorySystem.Core.Interfaces;
using InventorySystem.Core.States;

namespace InventorySystem.Services;

/// <summary>
/// Класс инвентаря.
/// Принцип Single Responsibility: отвечает только за хранение предметов и базовые операции добавления/удаления.
/// Принцип Open/Closed: работает с интерфейсом IItem, можно добавлять новые типы предметов без изменения кода.
/// </summary>
public class Inventory
{
    private readonly List<IItem> _items;
    private readonly int _maxQuantity; // Changed from maxWeight to maxQuantity
    private IInventoryState _state;

    public Inventory(int maxQuantity = 100) // Changed from maxWeight to maxQuantity
    {
        _items = new List<IItem>();
        _maxQuantity = maxQuantity;
        _state = new NormalInventoryState();
    }

    /// <summary>
    /// Текущая сумма количества предметов в инвентаре
    /// </summary>
    public int CurrentQuantity => _items.Sum(item => item.Quantity); // Changed from Weight to Quantity

    /// <summary>
    /// Максимальное количество предметов в инвентаре
    /// </summary>
    public int MaxQuantity => _maxQuantity; // Changed from Weight to Quantity

    /// <summary>
    /// Текущее состояние инвентаря
    /// </summary>
    public IInventoryState State => _state;

    /// <summary>
    /// Все предметы в инвентаре
    /// </summary>
    public IReadOnlyList<IItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Добавить предмет в инвентарь
    /// </summary>
    public bool AddItem(IItem item)
    {
        if (item == null)
            return false;

        if (!_state.CanAddItem(item, CurrentQuantity, _maxQuantity))
        {
            // Обновляем состояние даже если предмет не был добавлен
            // (на случай, если текущий вес уже превышает лимит)
            UpdateState();
            return false;
        }

        _items.Add(item);
        UpdateState();
        return true;
    }

    /// <summary>
    /// Удалить предмет из инвентаря
    /// </summary>
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

    /// <summary>
    /// Найти предмет по ID
    /// </summary>
    public IItem? FindItemById(string id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    /// <summary>
    /// Найти предметы по типу
    /// </summary>
    public IEnumerable<T> FindItemsByType<T>() where T : class, IItem
    {
        return _items.OfType<T>();
    }

    /// <summary>
    /// Обновить состояние инвентаря на основе текущего веса
    /// </summary>
    private void UpdateState()
    {
        var newState = _state.Transition(CurrentQuantity, _maxQuantity);
        if (newState != null)
        {
            _state = newState;
        }
    }
}

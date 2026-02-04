using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

/// <summary>
/// Базовый класс для всех предметов.
/// Принцип Single Responsibility: базовый класс отвечает только за общие свойства предметов.
/// </summary>
public abstract class BaseItem : IItem
{
    public string Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Quantity { get; set; } // Changed to include a public setter

    /// <summary>
    /// Состояние предмета (паттерн State)
    /// </summary>
    public IItemState? State { get; set; }

    protected BaseItem(string id, string name, string description, int quantity)
    {
        Id = id;
        Name = name;
        Description = description;
        Quantity = quantity;
    }

    public override string ToString()
    {
        var stateInfo = State != null ? $" [{State.Name}]" : "";
        return $"{Name} x{Quantity}{stateInfo}";
    }
}

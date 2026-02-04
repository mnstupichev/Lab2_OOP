namespace InventorySystem.Core.Interfaces;

/// <summary>
/// Базовый интерфейс для всех предметов в инвентаре.
/// Принцип Interface Segregation: минимальный интерфейс с общими свойствами.
/// </summary>
public interface IItem
{
    /// <summary>
    /// Уникальный идентификатор предмета
    /// </summary>
    string Id { get; }
    
    /// <summary>
    /// Название предмета
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Описание предмета
    /// </summary>
    string Description { get; }
    
    /// <summary>
    /// Количество предметов (для ограничения инвентаря)
    /// </summary>
    int Quantity { get; } // Изменено с Weight на Quantity
    
    /// <summary>
    /// Состояние предмета (паттерн State)
    /// </summary>
    IItemState? State { get; set; }
}

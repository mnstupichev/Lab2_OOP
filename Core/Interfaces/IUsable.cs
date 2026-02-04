namespace InventorySystem.Core.Interfaces;

/// <summary>
/// Интерфейс для предметов, которые можно использовать (зелья, еда и т.д.).
/// Принцип Interface Segregation: отдельный интерфейс для используемых предметов.
/// </summary>
public interface IUsable
{
    /// <summary>
    /// Можно ли использовать предмет в данный момент
    /// </summary>
    bool CanUse { get; }
    
    /// <summary>
    /// Использовать предмет
    /// </summary>
    /// <returns>Результат использования (например, восстановленное здоровье)</returns>
    UseResult Use();
}

/// <summary>
/// Результат использования предмета
/// </summary>
public class UseResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public Dictionary<string, object> Effects { get; set; } = new();
}

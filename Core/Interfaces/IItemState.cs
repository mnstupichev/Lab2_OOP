namespace InventorySystem.Core.Interfaces;

/// <summary>
/// Интерфейс состояния предмета (паттерн State).
/// Позволяет предмету менять поведение в зависимости от состояния.
/// </summary>
public interface IItemState
{
    /// <summary>
    /// Название состояния
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Модификатор характеристик предмета в этом состоянии
    /// </summary>
    double StatModifier { get; }
    
    /// <summary>
    /// Можно ли использовать предмет в этом состоянии
    /// </summary>
    bool CanUse { get; }
    
    /// <summary>
    /// Можно ли экипировать предмет в этом состоянии
    /// </summary>
    bool CanEquip { get; }
    
    /// <summary>
    /// Переход в следующее состояние (например, при улучшении или поломке)
    /// </summary>
    IItemState? Transition();
}

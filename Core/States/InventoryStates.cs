using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.States;

/// <summary>
/// Паттерн STATE для инвентаря.
/// 
/// ПРОБЛЕМА:
/// Инвентарь может быть в разных состояниях: нормальный (можно добавлять предметы),
/// перегруженный (нельзя добавлять новые предметы из-за превышения веса).
/// В каждом состоянии инвентарь ведет себя по-разному.
/// 
/// РЕШЕНИЕ:
/// Создаем интерфейс IInventoryState и конкретные состояния. Инвентарь делегирует
/// проверки и операции состояниям.
/// 
/// ПРИМЕР ИЗ РЕАЛЬНОЙ ЖИЗНИ:
/// Банковский счет: состояния "Активный" (можно снимать деньги), "Заблокирован"
/// (нельзя снимать), "Премиум" (нет комиссий). В каждом состоянии счет работает по-разному.
/// </summary>

/// <summary>
/// Интерфейс состояния инвентаря
/// </summary>
public interface IInventoryState
{
    /// <summary>
    /// Название состояния
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Можно ли добавить предмет в инвентарь в этом состоянии
    /// </summary>
    bool CanAddItem(IItem item, int currentQuantity, int maxQuantity); // Changed from Weight to Quantity

    /// <summary>
    /// Можно ли удалить предмет из инвентаря в этом состоянии
    /// </summary>
    bool CanRemoveItem();

    /// <summary>
    /// Переход в следующее состояние (например, при перегрузке или разгрузке)
    /// </summary>
    IInventoryState? Transition(int currentQuantity, int maxQuantity); // Changed from Weight to Quantity
}

/// <summary>
/// Нормальное состояние инвентаря - можно добавлять предметы, если есть место
/// </summary>
public class NormalInventoryState : IInventoryState
{
    public string Name => "Normal";

    public bool CanAddItem(IItem item, int currentQuantity, int maxQuantity)
    {
        // В нормальном состоянии можно добавить предмет, если не превышен лимит количества
        return currentQuantity + item.Quantity <= maxQuantity;
    }

    public bool CanRemoveItem()
    {
        return true; // В нормальном состоянии всегда можно удалить предмет
    }

    public IInventoryState? Transition(int currentQuantity, int maxQuantity)
    {
        // Если количество превысило лимит, переходим в перегруженное состояние
        if (currentQuantity > maxQuantity)
        {
            return new OverloadedInventoryState();
        }
        return null; // Остаемся в нормальном состоянии
    }
}

/// <summary>
/// Перегруженное состояние инвентаря - нельзя добавлять новые предметы
/// </summary>
public class OverloadedInventoryState : IInventoryState
{
    public string Name => "Overloaded";

    public bool CanAddItem(IItem item, int currentQuantity, int maxQuantity)
    {
        // В перегруженном состоянии нельзя добавлять новые предметы
        return false;
    }

    public bool CanRemoveItem()
    {
        return true; // Можно удалять предметы, чтобы разгрузить инвентарь
    }

    public IInventoryState? Transition(int currentQuantity, int maxQuantity)
    {
        // Если количество вернулось в норму, переходим в нормальное состояние
        if (currentQuantity <= maxQuantity)
        {
            return new NormalInventoryState();
        }
        return null; // Остаемся в перегруженном состоянии
    }
}

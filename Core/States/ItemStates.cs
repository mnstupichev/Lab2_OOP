using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.States;

/// <summary>
/// Паттерн STATE - позволяет объекту изменять свое поведение в зависимости от внутреннего состояния.
/// 
/// ПРОБЛЕМА, которую решает State:
/// Предмет может находиться в разных состояниях (нормальный, улучшенный, сломанный),
/// и в каждом состоянии он ведет себя по-разному. Без паттерна State пришлось бы
/// использовать множество if-else или switch-case, что усложняет код и нарушает OCP.
/// 
/// РЕШЕНИЕ:
/// Создаем отдельные классы для каждого состояния. Предмет хранит ссылку на текущее состояние
/// и делегирует ему выполнение операций. Состояния знают, как переходить в другие состояния.
/// 
/// ПРИМЕР ИЗ РЕАЛЬНОЙ ЖИЗНИ:
/// Светофор: состояния "Красный", "Желтый", "Зеленый". В каждом состоянии светофор
/// ведет себя по-разному (разрешает или запрещает движение), и знает, в какое состояние
/// перейти дальше.
/// </summary>

/// <summary>
/// Нормальное состояние предмета - базовое состояние без модификаторов
/// </summary>
public class NormalItemState : IItemState
{
    public string Name => "Normal";
    public double StatModifier => 1.0;
    public bool CanUse => true;
    public bool CanEquip => true;

    public IItemState? Transition()
    {
        // Из нормального состояния можно перейти в улучшенное или сломанное
        // В реальной игре это зависит от логики (улучшение через кузнеца, поломка от использования)
        return null; // По умолчанию остается в нормальном состоянии
    }
}

/// <summary>
/// Улучшенное состояние предмета - предмет получил улучшение и имеет бонусы
/// </summary>
public class UpgradedItemState : IItemState
{
    private readonly double _upgradeModifier;

    public UpgradedItemState(double upgradeModifier = 1.5)
    {
        _upgradeModifier = upgradeModifier;
    }

    public string Name => "Upgraded";
    public double StatModifier => _upgradeModifier; // Улучшенный предмет дает +50% к характеристикам
    public bool CanUse => true;
    public bool CanEquip => true;

    public IItemState? Transition()
    {
        // Из улучшенного состояния можно перейти в сломанное (если предмет сломался)
        // или вернуться в нормальное (если улучшение потеряно)
        return null;
    }
}

/// <summary>
/// Сломанное состояние предмета - предмет сломан и не может использоваться/экипироваться
/// </summary>
public class BrokenItemState : IItemState
{
    public string Name => "Broken";
    public double StatModifier => 0.0; // Сломанный предмет не дает характеристик
    public bool CanUse => false; // Сломанный предмет нельзя использовать
    public bool CanEquip => false; // Сломанный предмет нельзя экипировать

    public IItemState? Transition()
    {
        // Из сломанного состояния можно перейти в нормальное (если предмет починили)
        return new NormalItemState();
    }
}

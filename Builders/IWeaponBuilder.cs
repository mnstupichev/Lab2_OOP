using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Builders;

/// <summary>
/// Паттерн BUILDER - позволяет создавать сложные объекты пошагово.
/// 
/// ПРОБЛЕМА, которую решает Builder:
/// Когда объект имеет много параметров (оружие с уроном, типом урона, редкостью, эффектами и т.д.),
/// конструктор становится перегруженным. Также некоторые параметры могут быть опциональными,
/// и создавать множество перегрузок конструктора неудобно.
/// 
/// РЕШЕНИЕ:
/// Создаем класс Builder, который имеет методы для установки каждого параметра.
/// Методы возвращают сам Builder (fluent interface), что позволяет вызывать их цепочкой.
/// Финальный метод Build() создает объект с установленными параметрами.
/// 
/// ПРИМЕР ИЗ РЕАЛЬНОЙ ЖИЗНИ:
/// Строительство дома: есть строитель (Builder), который может установить фундамент,
/// стены, крышу, окна по отдельности. В конце вызывается метод "построить дом",
/// и получается готовый дом со всеми установленными компонентами.
/// 
/// В НАШЕМ СЛУЧАЕ:
/// WeaponBuilder позволяет создать сложное оружие с множеством параметров:
/// WithDamage(50).WithDamageType(Fire).WithDurability(200).Build()
/// </summary>
public interface IWeaponBuilder
{
    IWeaponBuilder WithName(string name);
    IWeaponBuilder WithDescription(string description);
    IWeaponBuilder WithDamage(int damage);
    IWeaponBuilder WithDamageType(DamageType damageType);
    IWeaponBuilder WithQuantity(int quantity); // Changed from Weight to Quantity
    IWeaponBuilder WithDurability(int durability);
    IWeaponBuilder WithState(IItemState state);
    Weapon Build();
}

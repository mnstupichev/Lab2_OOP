using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Core.States;

namespace InventorySystem.Builders;

/// <summary>
/// Конкретная реализация Builder для создания оружия.
/// Принцип Single Responsibility: отвечает только за построение оружия.
/// </summary>
public class WeaponBuilder : IWeaponBuilder
{
    private static int _weaponCounter = 0;
    
    private string _id = string.Empty;
    private string _name = "Unnamed Weapon";
    private string _description = "A weapon";
    private int _damage = 10;
    private DamageType _damageType = DamageType.Physical;
    private double _weight = 2.0;
    private int _durability = 100;
    private IItemState? _state;

    public IWeaponBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IWeaponBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public IWeaponBuilder WithDamage(int damage)
    {
        _damage = Math.Max(0, damage);
        return this;
    }

    public IWeaponBuilder WithDamageType(DamageType damageType)
    {
        _damageType = damageType;
        return this;
    }

    public IWeaponBuilder WithWeight(double weight)
    {
        _weight = Math.Max(0, weight);
        return this;
    }

    public IWeaponBuilder WithDurability(int durability)
    {
        _durability = Math.Max(0, durability);
        return this;
    }

    public IWeaponBuilder WithState(IItemState state)
    {
        _state = state;
        return this;
    }

    public Weapon Build()
    {
        // Генерируем ID, если не был установлен
        if (string.IsNullOrEmpty(_id))
        {
            _id = $"WEAPON_{++_weaponCounter}";
        }

        var weapon = new Weapon(
            id: _id,
            name: _name,
            description: _description,
            weight: _weight,
            baseDamage: _damage,
            damageType: _damageType,
            durability: _durability
        );

        // Устанавливаем состояние (по умолчанию Normal, если не указано)
        weapon.State = _state ?? new NormalItemState();

        return weapon;
    }
}

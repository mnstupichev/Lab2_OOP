namespace InventorySystem.Items.Weapon;

public class WeaponBuilder : IWeaponBuilder
{
    private string _name = "Weapon";
    private int _damage = 10;
    private DamageType _damageType = DamageType.Physical;
    private int _quantity = 1;
    private int _durability = 100;

    public IWeaponBuilder WithName(string name)
    {
        _name = name;
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

    public IWeaponBuilder WithQuantity(int quantity)
    {
        _quantity = Math.Max(1, quantity);
        return this;
    }

    public IWeaponBuilder WithDurability(int durability)
    {
        _durability = Math.Max(0, durability);
        return this;
    }

    public Weapon Build()
    {

        var weapon = new Weapon(
            name: _name,
            quantity: _quantity,
            baseDamage: _damage,
            damageType: _damageType,
            durability: _durability
        );

        return weapon;
    }
}

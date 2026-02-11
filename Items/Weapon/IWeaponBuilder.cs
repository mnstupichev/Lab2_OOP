namespace InventorySystem.Items.Weapon;

public interface IWeaponBuilder
{
    IWeaponBuilder WithName(string name);
    IWeaponBuilder WithDamage(int damage);
    IWeaponBuilder WithDamageType(DamageType damageType);
    IWeaponBuilder WithQuantity(int quantity); 
    IWeaponBuilder WithDurability(int durability);
    Weapon Build();
}

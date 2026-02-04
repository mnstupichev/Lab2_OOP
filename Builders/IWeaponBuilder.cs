using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Builders;

public interface IWeaponBuilder
{
    IWeaponBuilder WithName(string name);
    IWeaponBuilder WithDescription(string description);
    IWeaponBuilder WithDamage(int damage);
    IWeaponBuilder WithDamageType(DamageType damageType);
    IWeaponBuilder WithQuantity(int quantity); 
    IWeaponBuilder WithDurability(int durability);
    IWeaponBuilder WithState(IItemState state);
    Weapon Build();
}

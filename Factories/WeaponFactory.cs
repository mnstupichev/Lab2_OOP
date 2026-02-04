using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Factories;

public class WeaponFactory : IItemFactory
{
    private static int _weaponCounter = 0;

    public IItem CreateItem(string name)
    {
        var id = $"WEAPON_{++_weaponCounter}";
        var (damage, damageType, quantity, durability) = GetWeaponStats(name);
        
        var weapon = new Weapon(
            id: id,
            name: name,
            description: $"A weapon that deals {damage} {damageType} damage",
            quantity: quantity,
            baseDamage: damage,
            damageType: damageType,
            durability: durability
        );

        weapon.State = new Core.States.NormalItemState();
        
        return weapon;
    }

    private (int damage, DamageType type, int quantity, int durability) GetWeaponStats(string name)
    {
        var baseDamage = 25;

        var damageType = name.ToLower().Contains("fire") ? DamageType.Fire :
                        name.ToLower().Contains("ice") ? DamageType.Ice :
                        name.ToLower().Contains("lightning") ? DamageType.Lightning :
                        name.ToLower().Contains("poison") ? DamageType.Poison :
                        DamageType.Physical;

        var quantity = 1;

        var durability = 100;

        return (baseDamage, damageType, quantity, durability);
    }
}

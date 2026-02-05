using InventorySystem.Interfaces;
using InventorySystem.Items;

namespace InventorySystem.Services;

public class EnchantmentService
{
    private IEnchantmentStrategy? _currentStrategy;

    public void SetStrategy(IEnchantmentStrategy strategy)
    {
        _currentStrategy = strategy;
    }

    public EnchantmentResult EnchantWeapon(Weapon weapon)
    {
        if (_currentStrategy == null)
        {
            return new EnchantmentResult
            {
                Success = false,
                EnchantedItem = null,
                Enchantment = null
            };
        }

        if (weapon == null)
        {
            return new EnchantmentResult
            {
                Success = false,
                EnchantedItem = null,
                Enchantment = null
            };
        }

        int newDamage = _currentStrategy.ModifyDamage(weapon.BaseDamage);
        DamageType newDamageType = _currentStrategy.GetDamageType();

        var enchantedWeapon = new Weapon(
            name: weapon.Name,
            quantity: weapon.Quantity,
            baseDamage: newDamage,
            damageType: newDamageType,
            durability: weapon.Durability
        );

        foreach (var enchantment in weapon.Enchantments)
        {
            enchantedWeapon.AddEnchantment(enchantment);
        }

        enchantedWeapon.AddEnchantment(_currentStrategy.EnchantmentName);

        return new EnchantmentResult
        {
            Success = true,
            EnchantedItem = enchantedWeapon,
            Enchantment = null
        };
    }
}
using InventorySystem.Items.Weapon;

namespace InventorySystem.Enchantments;

public interface IEnchantment
{
    DamageType ChangeDamageType();
}
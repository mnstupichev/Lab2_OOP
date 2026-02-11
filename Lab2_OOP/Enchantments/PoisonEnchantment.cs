using InventorySystem.Items.Weapon;

namespace InventorySystem.Enchantments;


public class PoisonEnchantment : IEnchantment
{
public DamageType ChangeDamageType()
    {
        return DamageType.Poison;
    }
}

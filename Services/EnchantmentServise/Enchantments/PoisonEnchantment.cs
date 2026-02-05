using InventorySystem.Interfaces;

namespace InventorySystem.Enchantments;


public class PoisonEnchantment : IEnchantment
{
public DamageType ChangeDamageType(DamageType damageType)
    {
        return (DamageType)(DamageType.Poison);
    }
}

using InventorySystem.Interfaces;

namespace InventorySystem.Enchantments;

public class FireEnchantment : IEnchantment
{
    public DamageType ChangeDamageType(DamageType damageType)
    {
        return (DamageType)(DamageType.Fire);
    }
}

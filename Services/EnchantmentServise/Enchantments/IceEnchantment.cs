using InventorySystem.Interfaces;

namespace InventorySystem.Enchantments;

public class IceEnchantment : IEnchantment
{
public DamageType ChangeDamageType(DamageType damageType)
    {
        return (DamageType)(DamageType.Ice);
    }
}

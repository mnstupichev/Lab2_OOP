using InventorySystem.Interfaces;

namespace InventorySystem.Enchantments;

public class LightningEnchantment : IEnchantment
{
public DamageType ChangeDamageType(DamageType damageType)
    {
        return (DamageType)(DamageType.Lightning);
    }
}

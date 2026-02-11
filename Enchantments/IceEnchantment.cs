using InventorySystem.Items.Weapon;

namespace InventorySystem.Enchantments;

public class IceEnchantment : IEnchantment
{
public DamageType ChangeDamageType()
    {
        return DamageType.Ice;
    }
}

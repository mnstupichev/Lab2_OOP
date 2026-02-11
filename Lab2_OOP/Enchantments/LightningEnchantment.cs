using InventorySystem.Items.Weapon;

namespace InventorySystem.Enchantments;

public class LightningEnchantment : IEnchantment
{
public DamageType ChangeDamageType()
    {
        return DamageType.Lightning;
    }
}

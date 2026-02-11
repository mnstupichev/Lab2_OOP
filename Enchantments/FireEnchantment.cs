using InventorySystem.Items.Weapon;

namespace InventorySystem.Enchantments;

public class FireEnchantment : IEnchantment
{
    public DamageType ChangeDamageType()
    {
        return DamageType.Fire;
    }
}

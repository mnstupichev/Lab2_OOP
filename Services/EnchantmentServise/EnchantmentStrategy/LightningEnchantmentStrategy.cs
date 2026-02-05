using InventorySystem.Items;

namespace InventorySystem.Services;

public class LightningEnchantmentStrategy : IEnchantmentStrategy
{
    public string EnchantmentName => "Lightning Enchantment";

    public int ModifyDamage(int baseDamage)
    {
        return (int)(baseDamage * 1.7);
    }

    public DamageType GetDamageType()
    {
        return DamageType.Lightning;
    }
}
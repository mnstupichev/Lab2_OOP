using InventorySystem.Items;

namespace InventorySystem.Services;

public class FireEnchantmentStrategy : IEnchantmentStrategy
{
    public string EnchantmentName => "Fire Enchantment";

    public int ModifyDamage(int baseDamage)
    {
        return (int)(baseDamage * 1.5);
    }

    public DamageType GetDamageType()
    {
        return DamageType.Fire;
    }
}
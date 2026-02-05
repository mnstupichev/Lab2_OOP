using InventorySystem.Items;

namespace InventorySystem.Services;

public class IceEnchantmentStrategy : IEnchantmentStrategy
{
    public string EnchantmentName => "Ice Enchantment";

    public int ModifyDamage(int baseDamage)
    {
        return (int)(baseDamage * 1.3);
    }

    public DamageType GetDamageType()
    {
        return DamageType.Ice;
    }
}
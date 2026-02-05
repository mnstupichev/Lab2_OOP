using InventorySystem.Items;

namespace InventorySystem.Services;

public class PoisonEnchantmentStrategy : IEnchantmentStrategy
{
    public string EnchantmentName => "Poison Enchantment";

    public int ModifyDamage(int baseDamage)
    {
        return (int)(baseDamage * 1.4);
    }

    public DamageType GetDamageType()
    {
        return DamageType.Poison;
    }
}
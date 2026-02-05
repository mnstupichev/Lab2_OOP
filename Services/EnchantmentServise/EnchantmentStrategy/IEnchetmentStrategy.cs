using InventorySystem.Items;

namespace InventorySystem.Services;

public interface IEnchantmentStrategy
{
    string EnchantmentName { get; }
    int ModifyDamage(int baseDamage);
    DamageType GetDamageType();
}
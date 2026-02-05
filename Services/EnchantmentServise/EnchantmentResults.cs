using InventorySystem.Interfaces;

public class EnchantmentResult
{
    public bool Success { get; set; }
    public IItem? EnchantedItem { get; set; }
    public IEnchantment? Enchantment { get; set; }
}
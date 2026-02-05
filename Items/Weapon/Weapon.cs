using InventorySystem.Interfaces;

namespace InventorySystem.Items;

public class Weapon : BaseItem, IEquippable
{
    private readonly List<string> _enchantments;
    
    public int BaseDamage { get; private set; }
    public DamageType DamageType { get; private set; }
    public int Durability { get; private set; }
    public EquipmentSlot Slot => EquipmentSlot.Weapon;
    public bool IsEquipped { get; set; }
    public IReadOnlyList<string> Enchantments => _enchantments.AsReadOnly();

    public Weapon(
        string name,
        int quantity,
        int baseDamage,
        DamageType damageType,
        int durability = 100)
        : base(name, quantity)
    {
        BaseDamage = baseDamage;
        DamageType = damageType;
        Durability = durability;
        IsEquipped = false;
        _enchantments = new List<string>();
    }
    public void AddEnchantment(string enchantmentName)
    {
        if (!string.IsNullOrWhiteSpace(enchantmentName))
        {
            _enchantments.Add(enchantmentName);
        }
    }

    public void RemoveEnchantment(string enchantmentName)
    {
        _enchantments.Remove(enchantmentName);
    }

    public void ClearEnchantments()
    {
        _enchantments.Clear();
    }

    public bool HasEnchantment(string enchantmentName)
    {
        return _enchantments.Contains(enchantmentName);
    }
    
    public void Equip()
    {
        IsEquipped = true;
    }

    public void Unequip()
    {
        IsEquipped = false;
    }
}


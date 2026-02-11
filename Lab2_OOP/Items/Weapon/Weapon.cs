using Lab2_OOP.Enchantments;
using Lab2_OOP.Services.EquipmentServise;

namespace Lab2_OOP.Items.Weapon;

public class Weapon : BaseItem.BaseItem, IEquippable
{
    public int BaseDamage { get; private set; }
    public DamageType DamageType { get; private set; }
    public int Durability { get; private set; }
    public EquipmentSlot Slot => EquipmentSlot.Weapon;
    public bool IsEquipped { get; private set; }
    

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
    }
    
    public void AddEnchantment(IEnchantment enchantment)
    {
        DamageType = enchantment.ChangeDamageType();
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


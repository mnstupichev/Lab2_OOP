using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

public class Weapon : BaseItem, IEquippable
{
    public int BaseDamage { get; private set; }
    public DamageType DamageType { get; private set; }
    public int Durability { get; private set; }
    public EquipmentSlot Slot => EquipmentSlot.Weapon;
    public bool IsEquipped { get; set; }

    public Weapon(
        string id, 
        string name, 
        string description, 
        int quantity, 
        int baseDamage,
        DamageType damageType,
        int durability = 100) 
        : base(id, name, description, quantity) 
    {
        BaseDamage = baseDamage;
        DamageType = damageType;
        Durability = durability;
        IsEquipped = false;
    }
    public int GetCurrentDamage()
    {
        var modifier = State?.StatModifier ?? 1.0;
        return (int)(BaseDamage * modifier);
    }

    public void Equip()
    {
        if (State?.CanEquip == false)
        {
            IsEquipped = false;
            return;
        }
        IsEquipped = true;
    }

    public void Unequip()
    {
        IsEquipped = false;
    }
}

public enum DamageType
{
    Physical,   
    Fire,     
    Ice,        
    Lightning,  
    Poison    
}

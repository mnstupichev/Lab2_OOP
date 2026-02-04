using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

/// <summary>
/// Класс оружия.
/// Реализует IEquippable для возможности экипировки.
/// </summary>
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
        int quantity, // Changed from weight to quantity
        int baseDamage,
        DamageType damageType,
        int durability = 100) 
        : base(id, name, description, quantity) // Changed from weight to quantity
    {
        BaseDamage = baseDamage;
        DamageType = damageType;
        Durability = durability;
        IsEquipped = false;
    }

    /// <summary>
    /// Получить текущий урон с учетом состояния предмета
    /// </summary>
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

/// <summary>
/// Тип урона оружия
/// </summary>
public enum DamageType
{
    Physical,   // Физический
    Fire,       // Огненный
    Ice,        // Ледяной
    Lightning,  // Молния
    Poison      // Яд
}

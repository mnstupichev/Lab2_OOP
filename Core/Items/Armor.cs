using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

/// <summary>
/// Класс брони.
/// Реализует IEquippable для возможности экипировки.
/// </summary>
public class Armor : BaseItem, IEquippable
{
    public int BaseDefense { get; private set; }
    public int Durability { get; private set; }
    public EquipmentSlot Slot => EquipmentSlot.Armor;
    public bool IsEquipped { get; set; }

    public Armor(
        string id,
        string name,
        string description,
        int quantity,
        int baseDefense,
        int durability = 100)
        : base(id, name, description, quantity)
    {
        BaseDefense = baseDefense;
        Durability = durability;
        IsEquipped = false;
    }

    /// <summary>
    /// Получить текущую защиту с учетом состояния предмета
    /// </summary>
    public int GetCurrentDefense()
    {
        var modifier = State?.StatModifier ?? 1.0;
        return (int)(BaseDefense * modifier);
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

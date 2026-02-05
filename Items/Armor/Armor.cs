using InventorySystem.Interfaces;

namespace InventorySystem.Items;

public class Armor : BaseItem, IEquippable
{
    public int BaseDefense { get; private set; }
    public int Durability { get; private set; }
    public EquipmentSlot Slot => EquipmentSlot.Armor;
    public bool IsEquipped { get; set; }

    public Armor(
        string name,
        int quantity,
        int baseDefense,
        int durability = 100)
        : base(name, quantity)
    {
        BaseDefense = baseDefense;
        Durability = durability;
        IsEquipped = false;
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

namespace InventorySystem.Core.Interfaces;

public interface IEquippable
{
    EquipmentSlot Slot { get; }
    bool IsEquipped { get; set; }
    void Equip();
    void Unequip();
}

public enum EquipmentSlot
{
    Weapon,   
    Armor
}

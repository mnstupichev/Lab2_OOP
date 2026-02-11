namespace Lab2_OOP.Services.EquipmentServise;

public interface IEquippable
{
    EquipmentSlot Slot { get; }
    bool IsEquipped { get; }
    void Equip();
    void Unequip();
}


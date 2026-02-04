namespace InventorySystem.Core.Interfaces;

/// <summary>
/// Интерфейс для предметов, которые можно экипировать.
/// Принцип Interface Segregation: отдельный интерфейс для экипируемых предметов.
/// </summary>
public interface IEquippable
{
    /// <summary>
    /// Слот экипировки (оружие, броня и т.д.)
    /// </summary>
    EquipmentSlot Slot { get; }
    
    /// <summary>
    /// Экипирован ли предмет в данный момент
    /// </summary>
    bool IsEquipped { get; set; }
    
    /// <summary>
    /// Экипировать предмет
    /// </summary>
    void Equip();
    
    /// <summary>
    /// Снять предмет
    /// </summary>
    void Unequip();
}

/// <summary>
/// Типы слотов экипировки
/// </summary>
public enum EquipmentSlot
{
    Weapon,     // Оружие
    Armor,      // Броня
    Accessory   // Аксессуар (ювелирные изделия)
}

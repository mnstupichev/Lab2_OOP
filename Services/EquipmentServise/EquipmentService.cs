using InventorySystem.Interfaces;

namespace InventorySystem.Services;

public class EquipmentService
{
    private readonly Inventory _inventory;

    public EquipmentService(Inventory inventory)
    {
        _inventory = inventory;
    }

    public bool EquipItem(IItem item)
    {
        if (item is not IEquippable equippable)
            return false;

        if (equippable.Slot == EquipmentSlot.Weapon)
        {
            var equippedWeapons = GetEquippedWeapons().Count();
            if (equippedWeapons >= 2 && !equippable.IsEquipped)
                return false;
        }
        else
        {
            UnequipItemsInSlot(equippable.Slot);
        }

        equippable.Equip();
        return true;
    }

    public bool UnequipItem(IItem item)
    {
        if (item is not IEquippable equippable)
            return false;

        equippable.Unequip();
        return true;
    }

    private void UnequipItemsInSlot(EquipmentSlot slot)
    {
        var itemsInSlot = _inventory.Items
            .OfType<IEquippable>()
            .Where(item => item.Slot == slot && item.IsEquipped);

        foreach (var item in itemsInSlot)
        {
            item.Unequip();
        }
    }

    private IEnumerable<IEquippable> GetEquippedWeapons()
    {
        return _inventory.Items
            .OfType<IEquippable>()
            .Where(item => item.IsEquipped && item.Slot == EquipmentSlot.Weapon);
    }
}

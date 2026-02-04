using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Builders;

public interface IArmorBuilder
{
    IArmorBuilder WithName(string name);
    IArmorBuilder WithDescription(string description);
    IArmorBuilder WithDefense(int defense);
    IArmorBuilder WithQuantity(int quantity);
    IArmorBuilder WithDurability(int durability);
    IArmorBuilder WithState(IItemState state);
    Armor Build();
}

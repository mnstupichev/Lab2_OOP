namespace InventorySystem.Items;

public interface IArmorBuilder
{
    IArmorBuilder WithName(string name);
    IArmorBuilder WithDefense(int defense);
    IArmorBuilder WithQuantity(int quantity);
    IArmorBuilder WithDurability(int durability);
    Armor Build();
}

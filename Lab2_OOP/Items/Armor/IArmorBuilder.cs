namespace Lab2_OOP.Items.Armor;

public interface IArmorBuilder
{
    IArmorBuilder WithName(string name);
    IArmorBuilder WithDefense(int defense);
    IArmorBuilder WithQuantity(int quantity);
    IArmorBuilder WithDurability(int durability);
    Armor Build();
}

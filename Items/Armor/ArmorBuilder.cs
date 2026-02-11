namespace InventorySystem.Items.Armor;

public class ArmorBuilder : IArmorBuilder
{
    private string _name = "Armor";
    private int _defense = 10;
    private int _quantity = 1;
    private int _durability = 100;

    public IArmorBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IArmorBuilder WithDefense(int defense)
    {
        _defense = Math.Max(0, defense);
        return this;
    }

    public IArmorBuilder WithQuantity(int quantity)
    {
        _quantity = Math.Max(1, quantity);
        return this;
    }

    public IArmorBuilder WithDurability(int durability)
    {
        _durability = Math.Max(0, durability);
        return this;
    }

    public Armor Build()
    {
        var armor = new Armor(
            name: _name,
            quantity: _quantity,
            baseDefense: _defense,
            durability: _durability
        );

        return armor;
    }
}

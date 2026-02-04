using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Core.States;

namespace InventorySystem.Builders;

public class ArmorBuilder : IArmorBuilder
{
    private static int _armorCounter = 0;
    
    private string _id = string.Empty;
    private string _name = "Unnamed Armor";
    private string _description = "An armor";
    private int _defense = 10;
    private int _quantity = 1;
    private int _durability = 100;
    private IItemState? _state;

    public IArmorBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IArmorBuilder WithDescription(string description)
    {
        _description = description;
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

    public IArmorBuilder WithState(IItemState state)
    {
        _state = state;
        return this;
    }

    public Armor Build()
    {
        if (string.IsNullOrEmpty(_id))
        {
            _id = $"ARMOR_{++_armorCounter}";
        }

        var armor = new Armor(
            id: _id,
            name: _name,
            description: _description,
            quantity: _quantity,
            baseDefense: _defense,
            durability: _durability
        );

        armor.State = _state ?? new NormalItemState();

        return armor;
    }
}

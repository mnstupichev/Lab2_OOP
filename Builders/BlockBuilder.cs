using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Core.States;

namespace InventorySystem.Builders;

public class BlockBuilder : IBlockBuilder
{
    private static int _blockCounter = 0;
    
    private string _id = string.Empty;
    private string _name = "Unnamed Block";
    private string _description = "A block";
    private BlockMaterial _material = BlockMaterial.Stone;
    private int _quantity = 1;
    private int _durability = 100;
    private IItemState? _state;

    public IBlockBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IBlockBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public IBlockBuilder WithMaterial(BlockMaterial material)
    {
        _material = material;
        return this;
    }

    public IBlockBuilder WithQuantity(int quantity)
    {
        _quantity = Math.Max(1, quantity);
        return this;
    }

    public IBlockBuilder WithDurability(int durability)
    {
        _durability = Math.Max(0, durability);
        return this;
    }

    public IBlockBuilder WithState(IItemState state)
    {
        _state = state;
        return this;
    }

    public Block Build()
    {
        if (string.IsNullOrEmpty(_id))
        {
            _id = $"BLOCK_{++_blockCounter}";
        }

        var block = new Block(
            id: _id,
            name: _name,
            description: _description,
            quantity: _quantity,
            material: _material,
            durability: _durability
        );

        block.State = _state ?? new NormalItemState();

        return block;
    }
}

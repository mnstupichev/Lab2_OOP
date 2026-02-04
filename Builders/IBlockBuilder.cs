using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Builders;

public interface IBlockBuilder
{
    IBlockBuilder WithName(string name);
    IBlockBuilder WithDescription(string description);
    IBlockBuilder WithMaterial(BlockMaterial material);
    IBlockBuilder WithQuantity(int quantity);
    IBlockBuilder WithDurability(int durability);
    IBlockBuilder WithState(IItemState state);
    Block Build();
}

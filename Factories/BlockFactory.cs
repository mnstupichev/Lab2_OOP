using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Factories;

public class BlockFactory : IItemFactory
{
    private static int _blockCounter = 0;

    public IItem CreateItem(string name)
    {
        var id = $"BLOCK_{++_blockCounter}";
        var (material, quantity, durability) = GetBlockStats(name);
        
        var block = new Block(
            id: id,
            name: name,
            description: $"A {material} block",
            quantity: quantity,
            material: material,
            durability: durability
        );

        block.State = new Core.States.NormalItemState();
        
        return block;
    }

    private (BlockMaterial material, int quantity, int durability) GetBlockStats(string name)
    {
        var material = name.ToLower().Contains("stone") ? BlockMaterial.Stone :
                      name.ToLower().Contains("wood") ? BlockMaterial.Wood :
                      name.ToLower().Contains("metal") ? BlockMaterial.Metal :
                      name.ToLower().Contains("glass") ? BlockMaterial.Glass :
                      name.ToLower().Contains("dirt") ? BlockMaterial.Dirt :
                      name.ToLower().Contains("sand") ? BlockMaterial.Sand :
                      BlockMaterial.Stone;

        var quantity = 1;
        var durability = 100;

        return (material, quantity, durability);
    }
}

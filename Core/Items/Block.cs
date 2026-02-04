using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

public class Block : BaseItem, IUsable
{
    public BlockMaterial Material { get; private set; }
    public int Durability { get; private set; }
    public bool IsPlaced { get; private set; }

    public Block(
        string id,
        string name,
        string description,
        int quantity,
        BlockMaterial material,
        int durability = 100)
        : base(id, name, description, quantity)
    {
        Material = material;
        Durability = durability;
        IsPlaced = false;
    }

    public bool CanUse => !IsPlaced && (State?.CanUse ?? true);

    public UseResult Use()
    {
        if (!CanUse)
        {
            return new UseResult
            {
                Success = false,
                Message = $"{Name} cannot be placed"
            };
        }

        IsPlaced = true;
        var modifier = State?.StatModifier ?? 1.0;
        var effectiveDurability = (int)(Durability * modifier);

        return new UseResult
        {
            Success = true,
            Message = $"Placed {Name} block",
            Effects = new Dictionary<string, object>
            {
                { "Material", Material.ToString() },
                { "Durability", effectiveDurability },
                { "Placed", true }
            }
        };
    }
}

public enum BlockMaterial
{
    Stone,
    Wood,
    Metal,
    Glass,
    Dirt,
    Sand
}

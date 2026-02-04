namespace InventorySystem.Core.Interfaces;

public interface IUsable
{
    bool CanUse { get; }
    UseResult Use();
}

public class UseResult
{
    public bool Success { get; set; }
    public Dictionary<string, object> Effects { get; set; } = new();
}

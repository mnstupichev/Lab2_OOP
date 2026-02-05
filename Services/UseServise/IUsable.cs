namespace InventorySystem.Interfaces;

public interface IUsable
{
    bool CanUse { get; }
    UseResult Use();
}

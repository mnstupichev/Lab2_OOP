namespace InventorySystem.Core.Interfaces;

public interface IItemState
{
    string Name { get; }
    double StatModifier { get; }
    bool CanUse { get; }
    bool CanEquip { get; }
    IItemState? Transition();
}

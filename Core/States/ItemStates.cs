using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.States;
public class NormalItemState : IItemState
{
    public string Name => "Normal";
    public double StatModifier => 1.0;
    public bool CanUse => true;
    public bool CanEquip => true;

    public IItemState? Transition()
    {
        return null;
    }
}

public class UpgradedItemState : IItemState
{
    private readonly double _upgradeModifier;

    public UpgradedItemState(double upgradeModifier = 1.5)
    {
        _upgradeModifier = upgradeModifier;
    }

    public string Name => "Upgraded";
    public double StatModifier => _upgradeModifier;
    public bool CanUse => true;
    public bool CanEquip => true;

    public IItemState? Transition()
    {
        return null;
    }
}

public class BrokenItemState : IItemState
{
    public string Name => "Broken";
    public double StatModifier => 0.0;
    public bool CanUse => false;
    public bool CanEquip => false;

    public IItemState? Transition()
    {
        return new NormalItemState();
    }
}

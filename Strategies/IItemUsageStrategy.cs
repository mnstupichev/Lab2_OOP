using InventorySystem.Core.Interfaces;

namespace InventorySystem.Strategies;

public interface IItemUsageStrategy
{
    bool CanUse(IItem item);
    UseResult Use(IItem item);
    string StrategyName { get; }
}

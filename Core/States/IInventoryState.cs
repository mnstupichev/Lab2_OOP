using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.States;

public interface IInventoryState
{
    bool CanAddItem(IItem item, int currentQuantity, int maxQuantity);
    bool CanRemoveItem();
    IInventoryState? Transition(int currentQuantity, int maxQuantity);
}

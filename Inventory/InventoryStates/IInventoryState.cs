using InventorySystem.Interfaces;

namespace InventorySystem.States;

public interface IInventoryState
{
    bool CanAddItem(IItem item, int currentQuantity, int maxQuantity);
    bool CanRemoveItem();
    IInventoryState? Transition(int currentQuantity, int maxQuantity);
}

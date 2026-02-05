using InventorySystem.Interfaces;

namespace InventorySystem.States;

public class OverloadedInventoryState : IInventoryState
{
    public bool CanAddItem(IItem item, int currentQuantity, int maxQuantity)
    {
        return false;
    }

    public bool CanRemoveItem()
    {
        return true;
    }

    public IInventoryState? Transition(int currentQuantity, int maxQuantity)
    {
        if (currentQuantity <= maxQuantity)
        {
            return new NormalInventoryState();
        }
        return null;
    }
}

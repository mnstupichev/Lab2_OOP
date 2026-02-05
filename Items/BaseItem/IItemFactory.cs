using InventorySystem.Interfaces;

namespace InventorySystem.Factories;

public interface IItemFactory
{
    IItem CreateItem();
}

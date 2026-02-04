using InventorySystem.Core.Interfaces;

namespace InventorySystem.Factories;

public interface IItemFactory
{
    IItem CreateItem(string name);
}

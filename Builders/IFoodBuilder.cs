using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Builders;

public interface IFoodBuilder
{
    IFoodBuilder WithName(string name);
    IFoodBuilder WithDescription(string description);
    IFoodBuilder WithHealthRestoration(int healthRestoration);
    IFoodBuilder WithQuantity(int quantity);
    IFoodBuilder WithState(IItemState state);
    Food Build();
}

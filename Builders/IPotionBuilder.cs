using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Builders;

public interface IPotionBuilder
{
    IPotionBuilder WithName(string name);
    IPotionBuilder WithDescription(string description);
    IPotionBuilder WithEffect(PotionEffect effect);
    IPotionBuilder WithPotency(int potency);
    IPotionBuilder WithQuantity(int quantity);
    IPotionBuilder WithState(IItemState state);
    Potion Build();
}

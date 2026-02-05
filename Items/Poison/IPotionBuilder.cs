using InventorySystem.Items;

namespace InventorySystem.Builders;

public interface IPotionBuilder
{
    IPotionBuilder WithName(string name);
    IPotionBuilder WithEffect(PotionEffect effect);
    IPotionBuilder WithPotency(int potency);
    IPotionBuilder WithQuantity(int quantity);
    Potion Build();
}

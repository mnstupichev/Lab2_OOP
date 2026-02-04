using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Factories;

/// <summary>
/// Фабрика для создания зелий.
/// </summary>
public class PotionFactory : IItemFactory
{
    private static int _potionCounter = 0;

    public IItem CreateItem(string name)
    {
        var id = $"POTION_{++_potionCounter}";
        var (effect, potency, quantity) = GetPotionStats(name);
        
        var potion = new Potion(
            id: id,
            name: name,
            description: $"A potion that restores {potency} {effect}",
            quantity: quantity,
            effect: effect,
            potency: potency
        );

        potion.State = new Core.States.NormalItemState();
        
        return potion;
    }

    private (PotionEffect effect, int potency, int quantity) GetPotionStats(string name)
    {
        var effect = name.ToLower().Contains("health") ? PotionEffect.Health :
                    name.ToLower().Contains("fireprotection") ? PotionEffect.FireProtection :
                    name.ToLower().Contains("strength") ? PotionEffect.Strength :
                    name.ToLower().Contains("speed") ? PotionEffect.Speed :
                    PotionEffect.Health;

        var potency = 100; // Стандартная сила зелья
        var quantity = 1; // Стандартное количество зарядов

        return (effect, potency, quantity);
    }
}

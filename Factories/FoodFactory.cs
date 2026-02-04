using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Factories;

/// <summary>
/// Фабрика для создания еды.
/// </summary>
public class FoodFactory : IItemFactory
{
    private static int _foodCounter = 0;

    public IItem CreateItem(string name)
    {
        var id = $"FOOD_{++_foodCounter}";
        var (healthRestoration, quantity) = GetFoodStats(name);
        
        var food = new Food(
            id: id,
            name: name,
            description: $"A food that restores {healthRestoration} HP",
            quantity: quantity,
            healthRestoration: healthRestoration
        );

        food.State = new Core.States.NormalItemState();
        
        return food;
    }

    private (int healthRestoration, int quantity) GetFoodStats(string name)
    {
        var healthRestoration = 50; // Стандартное восстановление здоровья
        var quantity = 1; // Стандартное количество

        return (healthRestoration, quantity);
    }
}

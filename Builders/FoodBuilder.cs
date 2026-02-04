using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Core.States;

namespace InventorySystem.Builders;

public class FoodBuilder : IFoodBuilder
{
    private static int _foodCounter = 0;
    
    private string _id = string.Empty;
    private string _name = "Unnamed Food";
    private string _description = "A food";
    private int _healthRestoration = 25;
    private int _quantity = 1;
    private IItemState? _state;

    public IFoodBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IFoodBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public IFoodBuilder WithHealthRestoration(int healthRestoration)
    {
        _healthRestoration = Math.Max(0, healthRestoration);
        return this;
    }

    public IFoodBuilder WithQuantity(int quantity)
    {
        _quantity = Math.Max(1, quantity);
        return this;
    }

    public IFoodBuilder WithState(IItemState state)
    {
        _state = state;
        return this;
    }

    public Food Build()
    {
        if (string.IsNullOrEmpty(_id))
        {
            _id = $"FOOD_{++_foodCounter}";
        }

        var food = new Food(
            id: _id,
            name: _name,
            description: _description,
            quantity: _quantity,
            healthRestoration: _healthRestoration
        );

        food.State = _state ?? new NormalItemState();

        return food;
    }
}

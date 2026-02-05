using InventorySystem.Items;

namespace InventorySystem.Builders;

public class FoodBuilder : IFoodBuilder
{
    private string _name = "Food";
    private int _healthRestoration = 25;
    private int _quantity = 1;

    public IFoodBuilder WithName(string name)
    {
        _name = name;
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

    public Food Build()
    {

        var food = new Food(
            name: _name,
            quantity: _quantity,
            healthRestoration: _healthRestoration
        );

        return food;
    }
}

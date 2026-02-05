using Xunit;
using InventorySystem.Builders;
using InventorySystem.Factories;
using InventorySystem.Items;

namespace InventorySystem.Tests;

public class FoodTests
{
    [Fact]
    public void FoodBuilder_DefaultValues_CreatesFood()
    {
        var food = new FoodBuilder().Build();

        Assert.NotNull(food);
        Assert.Equal("Food", food.Name);
        Assert.Equal(1, food.Quantity);
    }

    [Fact]
    public void FoodBuilder_WithCustomValues_CreatesFood()
    {
        var food = new FoodBuilder()
            .WithName("Apple")
            .WithHealthRestoration(30)
            .WithQuantity(10)
            .Build();

        Assert.Equal("Apple", food.Name);
        Assert.Equal(10, food.Quantity);
    }

    [Fact]
    public void FoodBuilder_NegativeHealthRestoration_UsesMinimumValue()
    {
        var food = new FoodBuilder()
            .WithHealthRestoration(-15)
            .Build();

        Assert.NotNull(food);
    }

    [Fact]
    public void FoodFactory_CreateItem_ReturnsFood()
    {
        var factory = new FoodFactory();

        var item = factory.CreateItem();

        Assert.NotNull(item);
        Assert.IsType<Food>(item);
    }
}

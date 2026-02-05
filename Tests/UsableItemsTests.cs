using Xunit;
using InventorySystem.Builders;
using InventorySystem.Items;

namespace InventorySystem.Tests;

public class UsableItemsTests
{
    [Fact]
    public void Food_Use_DecreasesQuantity()
    {
        var food = new FoodBuilder()
            .WithName("Apple")
            .WithQuantity(5)
            .Build();

        var result = food.Use();

        Assert.True(result.Success);
        Assert.Equal(4, food.Quantity);
    }

    [Fact]
    public void Food_Use_MarksAsConsumed()
    {
        var food = new FoodBuilder()
            .WithQuantity(1)
            .Build();

        food.Use();

        Assert.False(food.CanUse);
    }

    [Fact]
    public void Food_Use_AlreadyConsumed_ReturnsFalse()
    {
        var food = new FoodBuilder()
            .WithQuantity(1)
            .Build();
        food.Use();

        var result = food.Use();

        Assert.False(result.Success);
    }

    [Fact]
    public void Food_CanUse_InitiallyTrue()
    {
        var food = new FoodBuilder().Build();

        Assert.True(food.CanUse);
    }

    [Fact]
    public void Potion_Use_DecreasesQuantity()
    {
        var potion = new PotionBuilder()
            .WithName("Health Potion")
            .WithQuantity(3)
            .Build();

        var result = potion.Use();

        Assert.True(result.Success);
        Assert.Equal(2, potion.Quantity);
    }

    [Fact]
    public void Potion_Use_ZeroQuantity_ReturnsFalse()
    {
        var potion = new PotionBuilder()
            .WithQuantity(1)
            .Build();
        potion.Use();

        var result = potion.Use();

        Assert.False(result.Success);
    }

    [Fact]
    public void Potion_CanUse_TrueWhenQuantityAboveZero()
    {
        var potion = new PotionBuilder()
            .WithQuantity(5)
            .Build();

        Assert.True(potion.CanUse);
    }

    [Fact]
    public void Potion_CanUse_FalseWhenQuantityZero()
    {
        var potion = new PotionBuilder()
            .WithQuantity(1)
            .Build();
        potion.Use();

        Assert.False(potion.CanUse);
    }

    [Fact]
    public void Potion_MultipleUses_WorksCorrectly()
    {
        var potion = new PotionBuilder()
            .WithQuantity(3)
            .Build();

        potion.Use();
        potion.Use();
        var result = potion.Use();

        Assert.True(result.Success);
        Assert.Equal(0, potion.Quantity);
        Assert.False(potion.CanUse);
    }
}

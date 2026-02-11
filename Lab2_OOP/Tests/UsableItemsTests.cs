using Lab2_OOP.Items.Food;
using Lab2_OOP.Items.Poison;
using Lab2_OOP.Services.UseServise;

namespace Lab2_OOP.Tests;

public class UsableItemsTests
{
    [Fact]
    public void Food_Use_DecreasesQuantity()
    {
        var food = new FoodBuilder()
            .WithName("Apple")
            .WithQuantity(5)
            .Build();
        
        food.Use();
        
        Assert.Equal(4, food.Quantity);
    }
    
    [Fact]
    public void Food_Use_ReturnsSuccess()
    {
        var food = new FoodBuilder()
            .WithName("Apple")
            .WithQuantity(5)
            .Build();

        UseResult result = food.Use();

        Assert.IsType<UseResult.Success>(result);
    }

    [Fact]
    public void Food_Use_MarksAsConsumed()
    {
        var food = new FoodBuilder()
            .WithName("Apple")
            .WithQuantity(5)
            .Build();

        food.Use();

        Assert.True(food.IsConsumed);
    }
    
    [Fact]
    public void Food_Use_WithoutEnoughQuantity_ReturnsFailure()
    {
        var food = new FoodBuilder()
            .WithName("Apple")
            .WithQuantity(1)
            .Build();
        
        food.Use();
        UseResult result = food.Use();

        Assert.IsType<UseResult.Failure>(result);
    }

    [Fact]
    public void Poison_Use_DecreasesQuantity()
    {
        var poison = new PotionBuilder()
            .WithName("Poison")
            .WithQuantity(5)
            .Build();
        
        poison.Use();
        
        Assert.Equal(4, poison.Quantity);
    }
    
    [Fact]
    public void Poison_Use_ReturnsSuccess()
    {
        var poison = new PotionBuilder()
            .WithName("Poison")
            .WithQuantity(5)
            .Build();
        
        UseResult result = poison.Use();

        Assert.IsType<UseResult.Success>(result);
    }
    
    [Fact]
    public void Poison_Use_WithoutEnoughQuantity_ReturnsFailure()
    {
        var poison = new PotionBuilder()
            .WithName("Poison")
            .WithQuantity(1)
            .Build();
        
        poison.Use();
        UseResult result = poison.Use();

        Assert.IsType<UseResult.Failure>(result);
    }
}

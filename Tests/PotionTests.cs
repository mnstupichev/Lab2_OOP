using Xunit;
using InventorySystem.Builders;
using InventorySystem.Factories;
using InventorySystem.Items;

namespace InventorySystem.Tests;

public class PotionTests
{
    [Fact]
    public void PotionBuilder_DefaultValues_CreatesPotion()
    {
        var potion = new PotionBuilder().Build();

        Assert.NotNull(potion);
        Assert.Equal("Potion", potion.Name);
        Assert.Equal(1, potion.Quantity);
    }

    [Fact]
    public void PotionBuilder_WithCustomValues_CreatesPotion()
    {
        var potion = new PotionBuilder()
            .WithName("Health Potion")
            .WithEffect(PotionEffect.Health)
            .WithPotency(75)
            .WithQuantity(5)
            .Build();

        Assert.Equal("Health Potion", potion.Name);
        Assert.Equal(5, potion.Quantity);
    }

    [Fact]
    public void PotionBuilder_NegativePotency_UsesMinimumValue()
    {
        var potion = new PotionBuilder()
            .WithPotency(-20)
            .Build();

        Assert.NotNull(potion);
    }

    [Fact]
    public void PotionFactory_CreateItem_ReturnsPotion()
    {
        var factory = new PotionFactory();

        var item = factory.CreateItem();

        Assert.NotNull(item);
        Assert.IsType<Potion>(item);
    }
}

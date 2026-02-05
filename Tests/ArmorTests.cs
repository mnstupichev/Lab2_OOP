using Xunit;
using InventorySystem.Items;
using InventorySystem.Factories;

namespace InventorySystem.Tests;

public class ArmorTests
{
    [Fact]
    public void ArmorBuilder_DefaultValues_CreatesArmor()
    {
        var armor = new ArmorBuilder().Build();

        Assert.NotNull(armor);
        Assert.Equal("Armor", armor.Name);
        Assert.Equal(1, armor.Quantity);
    }

    [Fact]
    public void ArmorBuilder_WithCustomValues_CreatesArmor()
    {
        var armor = new ArmorBuilder()
            .WithName("Steel Plate")
            .WithDefense(40)
            .WithQuantity(3)
            .WithDurability(200)
            .Build();

        Assert.Equal("Steel Plate", armor.Name);
        Assert.Equal(3, armor.Quantity);
    }

    [Fact]
    public void ArmorBuilder_NegativeDefense_UsesMinimumValue()
    {
        var armor = new ArmorBuilder()
            .WithDefense(-10)
            .Build();

        Assert.NotNull(armor);
    }

    [Fact]
    public void ArmorFactory_CreateItem_ReturnsArmor()
    {
        var factory = new ArmorFactory();

        var item = factory.CreateItem();

        Assert.NotNull(item);
        Assert.IsType<Armor>(item);
    }
}

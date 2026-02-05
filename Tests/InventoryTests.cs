using Xunit;
using InventorySystem.Services;
using InventorySystem.Items;
using InventorySystem.Builders;

namespace InventorySystem.Tests;

public class InventoryTests
{
    [Fact]
    public void AddItem_ValidItem_ReturnsTrue()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .WithQuantity(10)
            .Build();

        var result = inventory.AddItem(weapon);

        Assert.True(result);
        Assert.Single(inventory.Items);
        Assert.Equal(10, inventory.CurrentQuantity);
    }

    [Fact]
    public void AddItem_NullItem_ReturnsFalse()
    {
        var inventory = new Inventory(100);

        var result = inventory.AddItem(null);

        Assert.False(result);
        Assert.Empty(inventory.Items);
    }

    [Fact]
    public void AddItem_ExceedsCapacity_ReturnsFalse()
    {
        var inventory = new Inventory(50);
        var weapon = new WeaponBuilder()
            .WithQuantity(60)
            .Build();

        var result = inventory.AddItem(weapon);

        Assert.False(result);
        Assert.Empty(inventory.Items);
    }

    [Fact]
    public void RemoveItem_ExistingItem_ReturnsTrue()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .WithQuantity(10)
            .Build();
        inventory.AddItem(weapon);

        var result = inventory.RemoveItem(weapon);

        Assert.True(result);
        Assert.Empty(inventory.Items);
        Assert.Equal(0, inventory.CurrentQuantity);
    }

    [Fact]
    public void RemoveItem_NullItem_ReturnsFalse()
    {
        var inventory = new Inventory(100);

        var result = inventory.RemoveItem(null);

        Assert.False(result);
    }

    [Fact]
    public void CurrentQuantity_MultipleItems_CalculatesCorrectly()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder().WithQuantity(15).Build();
        var armor = new ArmorBuilder().WithQuantity(20).Build();

        inventory.AddItem(weapon);
        inventory.AddItem(armor);

        Assert.Equal(35, inventory.CurrentQuantity);
    }
}

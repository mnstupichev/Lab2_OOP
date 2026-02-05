using Xunit;
using InventorySystem.Services;
using InventorySystem.Builders;
using InventorySystem.States;

namespace InventorySystem.Tests;

public class InventoryStateTests
{
    [Fact]
    public void Inventory_InitialState_IsNormalState()
    {
        var inventory = new Inventory(100);

        Assert.IsType<NormalInventoryState>(inventory.State);
    }

    [Fact]
    public void Inventory_AddMultipleItems_UpdatesStateCorrectly()
    {
        var inventory = new Inventory(100);
        var weapon1 = new WeaponBuilder().WithQuantity(30).Build();
        var weapon2 = new WeaponBuilder().WithQuantity(40).Build();

        inventory.AddItem(weapon1);
        inventory.AddItem(weapon2);

        Assert.Equal(70, inventory.CurrentQuantity);
        Assert.NotNull(inventory.State);
    }

    [Fact]
    public void Inventory_RemoveItems_UpdatesStateCorrectly()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder().WithQuantity(50).Build();
        inventory.AddItem(weapon);

        inventory.RemoveItem(weapon);

        Assert.Equal(0, inventory.CurrentQuantity);
        Assert.IsType<NormalInventoryState>(inventory.State);
    }
}

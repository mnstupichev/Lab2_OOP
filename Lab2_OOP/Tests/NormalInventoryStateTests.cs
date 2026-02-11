using Lab2_OOP.InventoryFolder;
using Lab2_OOP.InventoryFolder.InventoryStates;
using Lab2_OOP.InventoryFolder.Results;
using Lab2_OOP.Items.Weapon;

namespace Lab2_OOP.Tests;

public class NormalInventoryStateTests
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
        var weapon1 = new WeaponBuilder()
            .WithQuantity(30)
            .Build();
        var weapon2 = new WeaponBuilder()
            .WithQuantity(40)
            .Build();

        inventory.AddItem(weapon1);
        inventory.AddItem(weapon2);

        Assert.Equal(70, inventory.CurrentQuantity);
    }

    [Fact]
    public void Inventory_RemoveItems_UpdatesStateCorrectly()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder()
            .WithQuantity(50)
            .Build();
        inventory.AddItem(weapon);

        inventory.RemoveItem(weapon);

        Assert.Equal(0, inventory.CurrentQuantity);
        Assert.IsType<NormalInventoryState>(inventory.State);
    }
    
    [Fact]
    public void Inventory_TryAddItem_WithoutEnoughtQuantity()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder()
            .WithQuantity(120)
            .Build();
        
        AddItemResult result = inventory.TryAddItem(weapon);

        Assert.Equal(0, inventory.CurrentQuantity);
        Assert.IsType<NormalInventoryState>(inventory.State);
        Assert.IsType<AddItemResult.NotEnoughtPlace>(result);
    }
    
    [Fact]
    public void Inventory_TryAddItem_WithEnoughtQuantity()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder()
            .WithQuantity(10)
            .Build();
        
        AddItemResult result = inventory.TryAddItem(weapon);

        Assert.Equal(10, inventory.CurrentQuantity);
        Assert.IsType<NormalInventoryState>(inventory.State);
        Assert.IsType<AddItemResult.Success>(result);
    }
}

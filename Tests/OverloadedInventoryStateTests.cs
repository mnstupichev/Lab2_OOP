using InventorySystem.InventoryFolder;
using InventorySystem.InventoryFolder.InventoryStates;
using InventorySystem.InventoryFolder.Results;
using InventorySystem.Items.Weapon;
using Xunit;

namespace InventorySystem.Tests;

public class OverloadedInventoryStateTests
{
    [Fact]
    public void Inventory_TryAddItem_WithFullInventory()
    {
        var inventory = new Inventory(100);
        var weapon1 = new WeaponBuilder()
            .WithQuantity(100)
            .Build();
        
        inventory.TryAddItem(weapon1);
        
        var weapon2 = new WeaponBuilder()
            .WithQuantity(10)
            .Build();
        
        AddItemResult result = inventory.TryAddItem(weapon2);

        Assert.Equal(100, inventory.CurrentQuantity);
        Assert.IsType<OverloadedInventoryState>(inventory.State);
        Assert.IsType<AddItemResult.AlreadyFull>(result);
    }
    
    [Fact]
    public void Inventory_TryRemoveItem_WithFullInventory()
    {
        var inventory = new Inventory(100);
        var weapon = new WeaponBuilder()
            .WithQuantity(100)
            .Build();
        
        inventory.AddItem(weapon);
        
        RemoveResult result = inventory.TryRemoveItem(weapon);

        Assert.Equal(0, inventory.CurrentQuantity);
        Assert.IsType<NormalInventoryState>(inventory.State);
        Assert.IsType<RemoveResult.Success>(result);
    }
}

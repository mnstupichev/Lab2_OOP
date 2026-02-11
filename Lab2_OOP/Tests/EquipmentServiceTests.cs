using InventorySystem.InventoryFolder;
using Xunit;
using InventorySystem.Items.Armor;
using InventorySystem.Items.Food;
using InventorySystem.Items.Poison;
using InventorySystem.Items.Weapon;
using InventorySystem.Services.EquipmentServise;

namespace InventorySystem.Tests;

public class EquipmentServiceTests
{
    [Fact]
    public void EquipItem_ValidWeapon_EquipsSuccessfully()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .Build();
        inventory.AddItem(weapon);

        var result = service.EquipItem(weapon);

        Assert.True(result);
        Assert.True(weapon.IsEquipped);
    }

    [Fact]
    public void EquipItem_ValidArmor_EquipsSuccessfully()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var armor = new ArmorBuilder()
            .WithName("Plate Mail")
            .Build();
        inventory.AddItem(armor);

        var result = service.EquipItem(armor);

        Assert.True(result);
        Assert.True(armor.IsEquipped);
    }

    [Fact]
    public void EquipItem_TwoWeapons_BothEquip()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var weapon1 = new WeaponBuilder().WithName("Sword").Build();
        var weapon2 = new WeaponBuilder().WithName("Dagger").Build();
        inventory.AddItem(weapon1);
        inventory.AddItem(weapon2);

        var result1 = service.EquipItem(weapon1);
        var result2 = service.EquipItem(weapon2);

        Assert.True(result1);
        Assert.True(result2);
        Assert.True(weapon1.IsEquipped);
        Assert.True(weapon2.IsEquipped);
    }

    [Fact]
    public void EquipItem_ThreeWeapons_ThirdFails()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var weapon1 = new WeaponBuilder().WithName("Sword").Build();
        var weapon2 = new WeaponBuilder().WithName("Dagger").Build();
        var weapon3 = new WeaponBuilder().WithName("Axe").Build();
        inventory.AddItem(weapon1);
        inventory.AddItem(weapon2);
        inventory.AddItem(weapon3);

        service.EquipItem(weapon1);
        service.EquipItem(weapon2);
        var result3 = service.EquipItem(weapon3);

        Assert.False(result3);
        Assert.False(weapon3.IsEquipped);
    }

    [Fact]
    public void EquipItem_SecondArmor_UnequipsFirst()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var armor1 = new ArmorBuilder().WithName("Leather").Build();
        var armor2 = new ArmorBuilder().WithName("Plate").Build();
        inventory.AddItem(armor1);
        inventory.AddItem(armor2);

        service.EquipItem(armor1);
        service.EquipItem(armor2);

        Assert.False(armor1.IsEquipped);
        Assert.True(armor2.IsEquipped);
    }

    [Fact]
    public void EquipItem_NonEquippableItem_ReturnsFalse()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var food = new FoodBuilder().Build();
        inventory.AddItem(food);

        var result = service.EquipItem(food);

        Assert.False(result);
    }

    [Fact]
    public void UnequipItem_EquippedWeapon_UnequipsSuccessfully()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var weapon = new WeaponBuilder().Build();
        inventory.AddItem(weapon);
        service.EquipItem(weapon);

        var result = service.UnequipItem(weapon);

        Assert.True(result);
        Assert.False(weapon.IsEquipped);
    }

    [Fact]
    public void UnequipItem_NonEquippableItem_ReturnsFalse()
    {
        var inventory = new Inventory(100);
        var service = new EquipmentService(inventory);
        var potion = new PotionBuilder().Build();

        var result = service.UnequipItem(potion);

        Assert.False(result);
    }
}

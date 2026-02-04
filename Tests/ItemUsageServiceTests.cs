using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Factories;
using InventorySystem.Services;
using Xunit;

namespace InventorySystem.Tests;

/// <summary>
/// Тесты для ItemUsageService.
/// Проверяют использование и экипировку предметов.
/// </summary>
public class ItemUsageServiceTests
{
    [Fact]
    public void UseItem_ShouldUsePotionSuccessfully()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new PotionFactory();
        var potion = (Potion)factory.CreateItem("Health Potion");
        inventory.AddItem(potion);

        // Act
        var result = service.UseItem(potion.Id);

        // Assert
        Assert.True(result.Success);
        Assert.Contains("Used", result.Message);
        Assert.Equal(0, potion.Quatity);
    }

    [Fact]
    public void UseItem_ShouldUseFoodSuccessfully()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new FoodFactory();
        var food = (Food)factory.CreateItem("Bread");
        inventory.AddItem(food);

        // Act
        var result = service.UseItem(food.Id);

        // Assert
        Assert.True(result.Success);
        Assert.Contains("Consumed", result.Message);
        Assert.True(food.IsConsumed);
        Assert.False(food.CanUse);
    }

    [Fact]
    public void EquipItem_ShouldEquipWeapon()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new WeaponFactory();
        var weapon = (Weapon)factory.CreateItem("Sword");
        inventory.AddItem(weapon);

        // Act
        var result = service.EquipItem(weapon.Id);

        // Assert
        Assert.True(result);
        Assert.True(weapon.IsEquipped);
    }

    [Fact]
    public void EquipItem_ShouldAllowTwoWeapons()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new WeaponFactory();
        var sword = (Weapon)factory.CreateItem("Sword");
        var axe = (Weapon)factory.CreateItem("Axe");
        var mace = (Weapon)factory.CreateItem("Mace");
        
        inventory.AddItem(sword);
        inventory.AddItem(axe);
        inventory.AddItem(mace);
        
        service.EquipItem(sword.Id);

        // Act - экипируем второе оружие
        var result1 = service.EquipItem(axe.Id);
        
        // Assert - оба оружия должны быть экипированы
        Assert.True(result1);
        Assert.True(sword.IsEquipped);
        Assert.True(axe.IsEquipped);
        
        // Act - пытаемся экипировать третье оружие
        var result2 = service.EquipItem(mace.Id);
        
        // Assert - третье оружие не должно экипироваться
        Assert.False(result2);
        Assert.False(mace.IsEquipped);
        Assert.True(sword.IsEquipped);
        Assert.True(axe.IsEquipped);
    }
    
    [Fact]
    public void EquipItem_ShouldUnequipPreviousArmorInSameSlot()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new ArmorFactory();
        var plateArmor = (Armor)factory.CreateItem("Plate Armor");
        var leatherArmor = (Armor)factory.CreateItem("Leather Armor");
        
        inventory.AddItem(plateArmor);
        inventory.AddItem(leatherArmor);
        
        service.EquipItem(plateArmor.Id);

        // Act
        service.EquipItem(leatherArmor.Id);

        // Assert - для брони должно сниматься предыдущее
        Assert.False(plateArmor.IsEquipped);
        Assert.True(leatherArmor.IsEquipped);
    }

    [Fact]
    public void EquipItem_ShouldNotEquipBrokenItem()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new WeaponFactory();
        var weapon = (Weapon)factory.CreateItem("Sword");
        weapon.State = new Core.States.BrokenItemState();
        inventory.AddItem(weapon);

        // Act
        var result = service.EquipItem(weapon.Id);

        // Assert
        Assert.False(result);
        Assert.False(weapon.IsEquipped);
    }

    [Fact]
    public void GetEquippedItems_ShouldReturnOnlyEquippedItems()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var weaponFactory = new WeaponFactory();
        var armorFactory = new ArmorFactory();
        
        var sword = (Weapon)weaponFactory.CreateItem("Sword");
        var armor = (Armor)armorFactory.CreateItem("Plate Armor");
        
        inventory.AddItem(sword);
        inventory.AddItem(armor);
        
        service.EquipItem(sword.Id);
        service.EquipItem(armor.Id);

        // Act
        var equipped = service.GetEquippedItems().ToList();

        // Assert
        Assert.Equal(2, equipped.Count);
        Assert.All(equipped, item => Assert.True(item.IsEquipped));
    }
}

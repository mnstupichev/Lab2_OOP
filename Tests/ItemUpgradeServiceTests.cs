using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Factories;
using InventorySystem.Services;
using Xunit;

namespace InventorySystem.Tests;

/// <summary>
/// Тесты для ItemUpgradeService.
/// Проверяют стандартное улучшение предметов.
/// </summary>
public class ItemUpgradeServiceTests
{
    [Fact]
    public void UpgradeItem_ShouldUpgradeWeapon()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUpgradeService(inventory, upgradeModifier: 1.5);
        var factory = new WeaponFactory();
        var weapon = (Weapon)factory.CreateItem("Sword");
        var originalDamage = weapon.GetCurrentDamage();
        inventory.AddItem(weapon);

        // Act
        var result = service.UpgradeItem(weapon.Id);

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result.UpgradedItem);
        Assert.Equal("Upgraded", weapon.State?.Name);
        Assert.True(weapon.GetCurrentDamage() > originalDamage);
        Assert.Contains("50%", result.Message);
    }

    [Fact]
    public void UpgradeItem_ShouldNotUpgradeAlreadyUpgradedItem()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUpgradeService(inventory);
        var factory = new WeaponFactory();
        var weapon = (Weapon)factory.CreateItem("Sword");
        weapon.State = new Core.States.UpgradedItemState();
        inventory.AddItem(weapon);

        // Act
        var result = service.UpgradeItem(weapon.Id);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("already upgraded", result.Message);
    }

    [Fact]
    public void UpgradeItem_ShouldNotUpgradeBrokenItem()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUpgradeService(inventory);
        var factory = new WeaponFactory();
        var weapon = (Weapon)factory.CreateItem("Sword");
        weapon.State = new Core.States.BrokenItemState();
        inventory.AddItem(weapon);

        // Act
        var result = service.UpgradeItem(weapon.Id);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("broken", result.Message);
    }

    [Fact]
    public void UpgradeItem_WithCustomModifier_ShouldUseCustomModifier()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUpgradeService(inventory, upgradeModifier: 2.0);
        var factory = new WeaponFactory();
        var weapon = (Weapon)factory.CreateItem("Sword");
        var originalDamage = weapon.GetCurrentDamage();
        inventory.AddItem(weapon);

        // Act
        var result = service.UpgradeItem(weapon.Id);

        // Assert
        Assert.True(result.Success);
        Assert.Contains("100%", result.Message);
        Assert.Equal(2.0, result.Changes["Modifier"]);
    }

    [Fact]
    public void UpgradeItem_WithNonExistentId_ShouldReturnFailure()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUpgradeService(inventory);

        // Act
        var result = service.UpgradeItem("non-existent-id");

        // Assert
        Assert.False(result.Success);
        Assert.Contains("not found", result.Message);
    }
}

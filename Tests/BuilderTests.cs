using InventorySystem.Builders;
using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Core.States;
using Xunit;

namespace InventorySystem.Tests;

/// <summary>
/// Тесты для паттерна Builder.
/// Проверяют создание сложных предметов через Builder.
/// </summary>
public class BuilderTests
{
    [Fact]
    public void WeaponBuilder_ShouldBuildWeaponWithAllProperties()
    {
        // Arrange & Act
        var weapon = new WeaponBuilder()
            .WithName("Legendary Fire Sword")
            .WithDescription("A powerful sword imbued with fire")
            .WithDamage(100)
            .WithDamageType(DamageType.Fire)
            .WithQuantity(5) // Changed from Weight to Quantity
            .Build();

        // Assert
        Assert.Equal("Legendary Fire Sword", weapon.Name);
        Assert.Equal(100, weapon.BaseDamage);
        Assert.Equal(DamageType.Fire, weapon.DamageType);
        Assert.Equal(5, weapon.Quantity); // Changed from Weight to Quantity
    }

    [Fact]
    public void WeaponBuilder_ShouldSetDefaultState()
    {
        // Arrange & Act
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .WithDamage(50)
            .Build();

        // Assert
        Assert.NotNull(weapon.State);
        Assert.Equal("Normal", weapon.State.Name);
    }

    [Fact]
    public void WeaponBuilder_ShouldSetCustomState()
    {
        // Arrange & Act
        var upgradedState = new UpgradedItemState(2.0);
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .WithDamage(50)
            .WithState(upgradedState)
            .Build();

        // Assert
        Assert.Equal(upgradedState, weapon.State);
        Assert.Equal("Upgraded", weapon.State.Name);
    }

    [Fact]
    public void WeaponBuilder_ShouldHandleNegativeDamage()
    {
        // Arrange
        var builder = new WeaponBuilder();

        // Act
        var weapon = builder.WithDamage(-10).Build();

        // Assert
        Assert.True(weapon.BaseDamage >= 0, "Weapon damage should not be negative.");
    }
}

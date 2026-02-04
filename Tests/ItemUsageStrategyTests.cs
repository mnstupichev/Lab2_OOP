using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Factories;
using InventorySystem.Services;
using InventorySystem.Strategies;
using Xunit;

namespace InventorySystem.Tests;

/// <summary>
/// Тесты для демонстрации использования Strategy паттерна для использования предметов.
/// Показывают, как один предмет может использоваться разными способами.
/// </summary>
public class ItemUsageStrategyTests
{
    [Fact]
    public void UseItem_WithConsumeStrategy_ShouldConsumePotion()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new PotionFactory();
        var potion = (Potion)factory.CreateItem("Health Potion");
        inventory.AddItem(potion);
        var initialCharges = potion.Quatity;

        var strategy = new ConsumeUsageStrategy();

        // Act
        var result = service.UseItem(potion.Id, strategy);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Consume", strategy.StrategyName);
        Assert.True(potion.Quatity < initialCharges);
    }

    [Fact]
    public void UseItem_WithThrowStrategy_ShouldThrowPotionAtEnemy()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new PotionFactory();
        var potion = (Potion)factory.CreateItem("Health Potion");
        inventory.AddItem(potion);
        var initialCharges = potion.Quatity;

        var strategy = new ThrowUsageStrategy();

        // Act
        var result = service.UseItem(potion.Id, strategy);

        // Assert
        Assert.True(result.Success);
        Assert.Contains("Threw", result.Message);
        Assert.Contains("damage", result.Message);
        Assert.True(result.Effects.ContainsKey("Damage"));
        Assert.True(potion.Quatity < initialCharges);
    }

    [Fact]
    public void UseItem_WithContextualStrategy_InCombat_ShouldReduceEffect()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new PotionFactory();
        var potion = (Potion)factory.CreateItem("Health Potion");
        inventory.AddItem(potion);

        var combatStrategy = new ContextualUsageStrategy(isInCombat: true);
        var safeStrategy = new ContextualUsageStrategy(isInCombat: false);

        // Act
        var combatResult = service.UseItem(potion.Id, combatStrategy);
        // Сбрасываем состояние для второго теста
        potion.Charges = 1;
        var safeResult = service.UseItem(potion.Id, safeStrategy);

        // Assert
        Assert.True(combatResult.Success);
        Assert.True(safeResult.Success);
        Assert.Contains("combat", combatResult.Message.ToLower());
        Assert.Contains("safe", safeResult.Message.ToLower());
        
        // В бою эффект меньше (70%), вне боя больше (120%)
        var combatPotency = (int)combatResult.Effects["Potency"];
        var safePotency = (int)safeResult.Effects["Potency"];
        Assert.True(safePotency > combatPotency);
    }

    [Fact]
    public void UseItem_WithEquipStrategy_ShouldEquipWeapon()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new WeaponFactory();
        var weapon = (Weapon)factory.CreateItem("Sword");
        inventory.AddItem(weapon);

        var strategy = new EquipUsageStrategy();

        // Act
        var result = service.UseItem(weapon.Id, strategy);

        // Assert
        Assert.True(result.Success);
        Assert.Contains("equipped", result.Message.ToLower());
        Assert.True(weapon.IsEquipped);
        Assert.True(result.Effects.ContainsKey("Equipped"));
    }

    [Fact]
    public void UseItem_WithDefaultStrategy_ShouldUseStandardBehavior()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new PotionFactory();
        var potion = (Potion)factory.CreateItem("Health Potion");
        inventory.AddItem(potion);

        // Act - используем без указания стратегии (используется стратегия по умолчанию)
        var result = service.UseItem(potion.Id);

        // Assert
        Assert.True(result.Success);
        // Стандартное поведение через интерфейс IUsable
    }

    [Fact]
    public void SetDefaultUsageStrategy_ShouldChangeDefaultBehavior()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new PotionFactory();
        var potion = (Potion)factory.CreateItem("Health Potion");
        inventory.AddItem(potion);

        // Act - меняем стратегию по умолчанию
        var throwStrategy = new ThrowUsageStrategy();
        service.SetDefaultUsageStrategy(throwStrategy);
        var result = service.UseItem(potion.Id); // Теперь использует throwStrategy по умолчанию

        // Assert
        Assert.True(result.Success);
        Assert.Contains("Threw", result.Message);
    }

    [Fact]
    public void UseItem_WithIncompatibleStrategy_ShouldFallbackToStandardBehavior()
    {
        // Arrange
        var inventory = new Inventory();
        var service = new ItemUsageService(inventory);
        var factory = new FoodFactory();
        var food = (Food)factory.CreateItem("Bread");
        inventory.AddItem(food);

        // Act - пытаемся использовать ThrowStrategy для еды (не подходит)
        var throwStrategy = new ThrowUsageStrategy();
        var result = service.UseItem(food.Id, throwStrategy);

        // Assert
        // Должно вернуться к стандартному поведению через IUsable
        Assert.True(result.Success);
        Assert.Contains("Consumed", result.Message);
    }
}

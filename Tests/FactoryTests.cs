using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Factories;
using Xunit;

namespace InventorySystem.Tests;

/// <summary>
/// Тесты для паттерна Abstract Factory.
/// Проверяют создание предметов через различные фабрики.
/// </summary>
public class FactoryTests
{
    [Fact]
    public void WeaponFactory_ShouldCreateWeapon()
    {
        // Arrange
        var factory = new WeaponFactory();

        // Act
        var item = factory.CreateItem("Sword");

        // Assert
        Assert.NotNull(item);
        Assert.IsType<Weapon>(item);
        Assert.Equal("Sword", item.Name);
    }

    [Fact]
    public void ArmorFactory_ShouldCreateArmor()
    {
        // Arrange
        var factory = new ArmorFactory();

        // Act
        var item = factory.CreateItem("Plate Armor");

        // Assert
        Assert.NotNull(item);
        Assert.IsType<Armor>(item);
        Assert.Equal("Plate Armor", item.Name);
    }

    [Fact]
    public void PotionFactory_ShouldCreatePotion()
    {
        // Arrange
        var factory = new PotionFactory();

        // Act
        var item = factory.CreateItem("Health Potion");

        // Assert
        Assert.NotNull(item);
        Assert.IsType<Potion>(item);
        var potion = (Potion)item;
        Assert.True(potion.Quatity > 0);
    }

    [Fact]
    public void FoodFactory_ShouldCreateFood()
    {
        // Arrange
        var factory = new FoodFactory();

        // Act
        var item = factory.CreateItem("Bread");

        // Assert
        Assert.NotNull(item);
        Assert.IsType<Food>(item);
        var food = (Food)item;
        Assert.True(food.HealthRestoration > 0);
    }

    [Fact]
    public void JewelryFactory_ShouldCreateJewelry()
    {
        // Arrange
        var factory = new JewelryFactory();

        // Act
        var item = factory.CreateItem("Strength Ring");

        // Assert
        Assert.NotNull(item);
        Assert.IsType<Jewelry>(item);
        var jewelry = (Jewelry)item;
        Assert.NotEmpty(jewelry.StatBonuses);
    }

    [Fact]
    public void QuestItemFactory_ShouldCreateQuestItem()
    {
        // Arrange
        var factory = new QuestItemFactory();

        // Act
        var item = factory.CreateItem("Ancient Artifact");

        // Assert
        Assert.NotNull(item);
        Assert.IsType<QuestItem>(item);
        var questItem = (QuestItem)item;
        Assert.NotEmpty(questItem.QuestId);
    }
}

using Xunit;
using InventorySystem.Items.Armor;
using InventorySystem.Items.Food;
using InventorySystem.Items.Poison;
using InventorySystem.Items.Weapon;

namespace InventorySystem.Tests;

public class BuilderFluentInterfaceTests
{
    [Fact]
    public void WeaponBuilder_FluentInterface_ChainsCorrectly()
    {
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .WithDamage(25)
            .WithDamageType(DamageType.Physical)
            .WithQuantity(1)
            .WithDurability(100)
            .Build();
        
        Assert.Equal("Sword", weapon.Name);
        Assert.Equal(25, weapon.BaseDamage);
        Assert.Equal(DamageType.Physical, weapon.DamageType);
        Assert.Equal(1, weapon.Quantity);
        Assert.Equal(100, weapon.Durability);
    }

    [Fact]
    public void ArmorBuilder_FluentInterface_ChainsCorrectly()
    {
        var armor = new ArmorBuilder()
            .WithName("Shield")
            .WithDefense(15)
            .WithQuantity(1)
            .WithDurability(100)
            .Build();

        Assert.Equal("Shield", armor.Name);
        Assert.Equal(15, armor.BaseDefense);
        Assert.Equal(1, armor.Quantity);
        Assert.Equal(100, armor.Durability);
    }

    [Fact]
    public void PotionBuilder_FluentInterface_ChainsCorrectly()
    {
        var potion = new PotionBuilder()
            .WithName("Mana Potion")
            .WithEffect(PotionEffect.Speed)
            .WithPotency(60)
            .WithQuantity(3)
            .Build();

        Assert.Equal("Mana Potion", potion.Name);
        Assert.Equal(PotionEffect.Speed, potion.Effect);
        Assert.Equal(60, potion.Potency);
        Assert.Equal(3, potion.Quantity);
    }

    [Fact]
    public void FoodBuilder_FluentInterface_ChainsCorrectly()
    {
        var food = new FoodBuilder()
            .WithName("Bread")
            .WithHealthRestoration(20)
            .WithQuantity(5)
            .Build();

        Assert.Equal("Bread", food.Name);
        Assert.Equal(20, food.HealthRestoration);
        Assert.Equal(5, food.Quantity);
    }
}

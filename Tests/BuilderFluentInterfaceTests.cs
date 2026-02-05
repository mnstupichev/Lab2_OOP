using Xunit;
using InventorySystem.Builders;
using InventorySystem.Items;

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

        Assert.NotNull(weapon);
        Assert.Equal("Sword", weapon.Name);
    }

    [Fact]
    public void ArmorBuilder_FluentInterface_ChainsCorrectly()
    {
        var armor = new ArmorBuilder()
            .WithName("Shield")
            .WithDefense(15)
            .WithQuantity(1)
            .WithDurability(120)
            .Build();

        Assert.NotNull(armor);
        Assert.Equal("Shield", armor.Name);
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

        Assert.NotNull(potion);
        Assert.Equal("Mana Potion", potion.Name);
    }

    [Fact]
    public void FoodBuilder_FluentInterface_ChainsCorrectly()
    {
        var food = new FoodBuilder()
            .WithName("Bread")
            .WithHealthRestoration(20)
            .WithQuantity(5)
            .Build();

        Assert.NotNull(food);
        Assert.Equal("Bread", food.Name);
    }
}

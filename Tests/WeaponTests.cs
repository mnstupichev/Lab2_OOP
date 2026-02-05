using Xunit;
using InventorySystem.Builders;
using InventorySystem.Factories;
using InventorySystem.Items;

namespace InventorySystem.Tests;

public class WeaponTests
{
    [Fact]
    public void WeaponBuilder_DefaultValues_CreatesWeapon()
    {
        var weapon = new WeaponBuilder().Build();

        Assert.NotNull(weapon);
        Assert.Equal("Weapon", weapon.Name);
        Assert.Equal(1, weapon.Quantity);
    }

    [Fact]
    public void WeaponBuilder_WithCustomValues_CreatesWeapon()
    {
        var weapon = new WeaponBuilder()
            .WithName("Excalibur")
            .WithDamage(50)
            .WithDamageType(DamageType.Fire)
            .WithQuantity(2)
            .WithDurability(150)
            .Build();

        Assert.Equal("Excalibur", weapon.Name);
        Assert.Equal(2, weapon.Quantity);
    }

    [Fact]
    public void WeaponBuilder_NegativeQuantity_UsesMinimumValue()
    {
        var weapon = new WeaponBuilder()
            .WithQuantity(-5)
            .Build();

        Assert.Equal(1, weapon.Quantity);
    }

    [Fact]
    public void WeaponFactory_CreateItem_ReturnsWeapon()
    {
        var factory = new WeaponFactory();

        var item = factory.CreateItem();

        Assert.NotNull(item);
        Assert.IsType<Weapon>(item);
    }
}

using Xunit;
using InventorySystem.Services;
using InventorySystem.Items;

namespace InventorySystem.Tests;

public class EnchantmentStrategyTests
{
    [Fact]
    public void FireEnchantmentStrategy_ModifyDamage_IncreasesBy50Percent()
    {
        var strategy = new FireEnchantmentStrategy();
        var baseDamage = 100;

        var modifiedDamage = strategy.ModifyDamage(baseDamage);

        Assert.Equal(150, modifiedDamage);
    }

    [Fact]
    public void FireEnchantmentStrategy_GetDamageType_ReturnsFire()
    {
        var strategy = new FireEnchantmentStrategy();

        var damageType = strategy.GetDamageType();

        Assert.Equal(DamageType.Fire, damageType);
    }

    [Fact]
    public void IceEnchantmentStrategy_ModifyDamage_IncreasesBy30Percent()
    {
        var strategy = new IceEnchantmentStrategy();
        var baseDamage = 100;

        var modifiedDamage = strategy.ModifyDamage(baseDamage);

        Assert.Equal(130, modifiedDamage);
    }

    [Fact]
    public void IceEnchantmentStrategy_GetDamageType_ReturnsIce()
    {
        var strategy = new IceEnchantmentStrategy();

        var damageType = strategy.GetDamageType();

        Assert.Equal(DamageType.Ice, damageType);
    }

    [Fact]
    public void LightningEnchantmentStrategy_ModifyDamage_IncreasesBy70Percent()
    {
        var strategy = new LightningEnchantmentStrategy();
        var baseDamage = 100;

        var modifiedDamage = strategy.ModifyDamage(baseDamage);

        Assert.Equal(170, modifiedDamage);
    }

    [Fact]
    public void LightningEnchantmentStrategy_GetDamageType_ReturnsLightning()
    {
        var strategy = new LightningEnchantmentStrategy();

        var damageType = strategy.GetDamageType();

        Assert.Equal(DamageType.Lightning, damageType);
    }

    [Fact]
    public void PoisonEnchantmentStrategy_ModifyDamage_IncreasesBy40Percent()
    {
        var strategy = new PoisonEnchantmentStrategy();
        var baseDamage = 100;

        var modifiedDamage = strategy.ModifyDamage(baseDamage);

        Assert.Equal(140, modifiedDamage);
    }

    [Fact]
    public void PoisonEnchantmentStrategy_GetDamageType_ReturnsPoison()
    {
        var strategy = new PoisonEnchantmentStrategy();

        var damageType = strategy.GetDamageType();

        Assert.Equal(DamageType.Poison, damageType);
    }
}

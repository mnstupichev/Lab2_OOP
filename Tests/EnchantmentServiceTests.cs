using Xunit;
using InventorySystem.Services;
using InventorySystem.Builders;
using InventorySystem.Items;

namespace InventorySystem.Tests;

public class EnchantmentServiceTests
{
    [Fact]
    public void EnchantWeapon_WithFireStrategy_IncreaseDamageAndChangesType()
    {
        var service = new EnchantmentService();
        service.SetStrategy(new FireEnchantmentStrategy());
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .WithDamage(100)
            .WithDamageType(DamageType.Physical)
            .Build();

        var result = service.EnchantWeapon(weapon);

        Assert.True(result.Success);
        Assert.NotNull(result.EnchantedItem);
        var enchantedWeapon = result.EnchantedItem as Weapon;
        Assert.NotNull(enchantedWeapon);
        Assert.Equal(150, enchantedWeapon.BaseDamage);
        Assert.Equal(DamageType.Fire, enchantedWeapon.DamageType);
    }

    [Fact]
    public void EnchantWeapon_WithIceStrategy_IncreaseDamageAndChangesType()
    {
        var service = new EnchantmentService();
        service.SetStrategy(new IceEnchantmentStrategy());
        var weapon = new WeaponBuilder()
            .WithDamage(100)
            .Build();

        var result = service.EnchantWeapon(weapon);

        Assert.True(result.Success);
        var enchantedWeapon = result.EnchantedItem as Weapon;
        Assert.Equal(130, enchantedWeapon.BaseDamage);
        Assert.Equal(DamageType.Ice, enchantedWeapon.DamageType);
    }

    [Fact]
    public void EnchantWeapon_WithLightningStrategy_IncreaseDamageAndChangesType()
    {
        var service = new EnchantmentService();
        service.SetStrategy(new LightningEnchantmentStrategy());
        var weapon = new WeaponBuilder()
            .WithDamage(100)
            .Build();

        var result = service.EnchantWeapon(weapon);

        Assert.True(result.Success);
        var enchantedWeapon = result.EnchantedItem as Weapon;
        Assert.Equal(170, enchantedWeapon.BaseDamage);
        Assert.Equal(DamageType.Lightning, enchantedWeapon.DamageType);
    }

    [Fact]
    public void EnchantWeapon_WithPoisonStrategy_IncreaseDamageAndChangesType()
    {
        var service = new EnchantmentService();
        service.SetStrategy(new PoisonEnchantmentStrategy());
        var weapon = new WeaponBuilder()
            .WithDamage(100)
            .Build();

        var result = service.EnchantWeapon(weapon);

        Assert.True(result.Success);
        var enchantedWeapon = result.EnchantedItem as Weapon;
        Assert.Equal(140, enchantedWeapon.BaseDamage);
        Assert.Equal(DamageType.Poison, enchantedWeapon.DamageType);
    }

    [Fact]
    public void EnchantWeapon_NullWeapon_ReturnsFalse()
    {
        var service = new EnchantmentService();
        service.SetStrategy(new FireEnchantmentStrategy());

        var result = service.EnchantWeapon(null);

        Assert.False(result.Success);
        Assert.Null(result.EnchantedItem);
    }

    [Fact]
    public void EnchantWeapon_NoStrategySet_ReturnsFalse()
    {
        var service = new EnchantmentService();
        var weapon = new WeaponBuilder().Build();

        var result = service.EnchantWeapon(weapon);

        Assert.False(result.Success);
        Assert.Null(result.EnchantedItem);
    }

    [Fact]
    public void EnchantWeapon_PreservesExistingEnchantments()
    {
        var service = new EnchantmentService();
        var weapon = new WeaponBuilder()
            .WithDamage(100)
            .Build();
        weapon.AddEnchantment("Previous Enchantment");

        service.SetStrategy(new FireEnchantmentStrategy());
        var result = service.EnchantWeapon(weapon);

        var enchantedWeapon = result.EnchantedItem as Weapon;
        Assert.NotNull(enchantedWeapon);
        Assert.True(enchantedWeapon.HasEnchantment("Previous Enchantment"));
        Assert.True(enchantedWeapon.HasEnchantment("Fire Enchantment"));
    }

    [Fact]
    public void EnchantWeapon_AddsEnchantmentName()
    {
        var service = new EnchantmentService();
        service.SetStrategy(new FireEnchantmentStrategy());
        var weapon = new WeaponBuilder().Build();

        var result = service.EnchantWeapon(weapon);

        var enchantedWeapon = result.EnchantedItem as Weapon;
        Assert.True(enchantedWeapon.HasEnchantment("Fire Enchantment"));
    }
}

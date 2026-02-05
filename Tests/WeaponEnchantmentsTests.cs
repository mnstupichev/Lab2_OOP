using Xunit;
using InventorySystem.Builders;

namespace InventorySystem.Tests;

public class WeaponEnchantmentsTests
{
    [Fact]
    public void AddEnchantment_ValidName_AddsEnchantment()
    {
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .Build();

        weapon.AddEnchantment("Fire");

        Assert.True(weapon.HasEnchantment("Fire"));
        Assert.Single(weapon.Enchantments);
    }

    [Fact]
    public void AddEnchantment_MultipleEnchantments_AddsAll()
    {
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .Build();

        weapon.AddEnchantment("Fire");
        weapon.AddEnchantment("Ice");
        weapon.AddEnchantment("Lightning");

        Assert.Equal(3, weapon.Enchantments.Count);
        Assert.True(weapon.HasEnchantment("Fire"));
        Assert.True(weapon.HasEnchantment("Ice"));
        Assert.True(weapon.HasEnchantment("Lightning"));
    }

    [Fact]
    public void AddEnchantment_EmptyString_DoesNotAdd()
    {
        var weapon = new WeaponBuilder().Build();

        weapon.AddEnchantment("");

        Assert.Empty(weapon.Enchantments);
    }

    [Fact]
    public void AddEnchantment_Whitespace_DoesNotAdd()
    {
        var weapon = new WeaponBuilder().Build();

        weapon.AddEnchantment("   ");

        Assert.Empty(weapon.Enchantments);
    }

    [Fact]
    public void RemoveEnchantment_ExistingEnchantment_Removes()
    {
        var weapon = new WeaponBuilder().Build();
        weapon.AddEnchantment("Fire");

        weapon.RemoveEnchantment("Fire");

        Assert.False(weapon.HasEnchantment("Fire"));
        Assert.Empty(weapon.Enchantments);
    }

    [Fact]
    public void RemoveEnchantment_NonExistingEnchantment_NoEffect()
    {
        var weapon = new WeaponBuilder().Build();
        weapon.AddEnchantment("Fire");

        weapon.RemoveEnchantment("Ice");

        Assert.Single(weapon.Enchantments);
        Assert.True(weapon.HasEnchantment("Fire"));
    }

    [Fact]
    public void ClearEnchantments_RemovesAll()
    {
        var weapon = new WeaponBuilder().Build();
        weapon.AddEnchantment("Fire");
        weapon.AddEnchantment("Ice");
        weapon.AddEnchantment("Lightning");

        weapon.ClearEnchantments();

        Assert.Empty(weapon.Enchantments);
        Assert.False(weapon.HasEnchantment("Fire"));
        Assert.False(weapon.HasEnchantment("Ice"));
        Assert.False(weapon.HasEnchantment("Lightning"));
    }

    [Fact]
    public void HasEnchantment_ExistingEnchantment_ReturnsTrue()
    {
        var weapon = new WeaponBuilder().Build();
        weapon.AddEnchantment("Fire");

        var result = weapon.HasEnchantment("Fire");

        Assert.True(result);
    }

    [Fact]
    public void HasEnchantment_NonExistingEnchantment_ReturnsFalse()
    {
        var weapon = new WeaponBuilder().Build();

        var result = weapon.HasEnchantment("Fire");

        Assert.False(result);
    }

    [Fact]
    public void Enchantments_ReadOnlyList_CannotModifyDirectly()
    {
        var weapon = new WeaponBuilder().Build();
        weapon.AddEnchantment("Fire");

        var enchantments = weapon.Enchantments;

        Assert.IsAssignableFrom<System.Collections.Generic.IReadOnlyList<string>>(enchantments);
    }

    [Fact]
    public void Weapon_InitialState_NoEnchantments()
    {
        var weapon = new WeaponBuilder().Build();

        Assert.Empty(weapon.Enchantments);
    }
}

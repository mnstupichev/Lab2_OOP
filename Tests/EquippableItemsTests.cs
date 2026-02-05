using Xunit;
using InventorySystem.Builders;
using InventorySystem.Items;

namespace InventorySystem.Tests;

public class EquippableItemsTests
{
    [Fact]
    public void Weapon_Equip_SetsIsEquippedTrue()
    {
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .Build();

        weapon.Equip();

        Assert.True(weapon.IsEquipped);
    }

    [Fact]
    public void Weapon_Unequip_SetsIsEquippedFalse()
    {
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .Build();
        weapon.Equip();

        weapon.Unequip();

        Assert.False(weapon.IsEquipped);
    }

    [Fact]
    public void Weapon_InitialState_IsNotEquipped()
    {
        var weapon = new WeaponBuilder().Build();

        Assert.False(weapon.IsEquipped);
    }

    [Fact]
    public void Weapon_Slot_ReturnsWeaponSlot()
    {
        var weapon = new WeaponBuilder().Build();

        Assert.Equal(EquipmentSlot.Weapon, weapon.Slot);
    }

    [Fact]
    public void Armor_Equip_SetsIsEquippedTrue()
    {
        var armor = new ArmorBuilder()
            .WithName("Plate Mail")
            .Build();

        armor.Equip();

        Assert.True(armor.IsEquipped);
    }

    [Fact]
    public void Armor_Unequip_SetsIsEquippedFalse()
    {
        var armor = new ArmorBuilder()
            .WithName("Plate Mail")
            .Build();
        armor.Equip();

        armor.Unequip();

        Assert.False(armor.IsEquipped);
    }

    [Fact]
    public void Armor_InitialState_IsNotEquipped()
    {
        var armor = new ArmorBuilder().Build();

        Assert.False(armor.IsEquipped);
    }

    [Fact]
    public void Armor_Slot_ReturnsArmorSlot()
    {
        var armor = new ArmorBuilder().Build();

        Assert.Equal(EquipmentSlot.Armor, armor.Slot);
    }

    [Fact]
    public void Weapon_EquipUnequipMultipleTimes_WorksCorrectly()
    {
        var weapon = new WeaponBuilder().Build();

        weapon.Equip();
        weapon.Unequip();
        weapon.Equip();

        Assert.True(weapon.IsEquipped);
    }

    [Fact]
    public void Armor_EquipUnequipMultipleTimes_WorksCorrectly()
    {
        var armor = new ArmorBuilder().Build();

        armor.Equip();
        armor.Unequip();
        armor.Equip();

        Assert.True(armor.IsEquipped);
    }
}

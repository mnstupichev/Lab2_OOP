using InventorySystem.Enchantments;
using InventorySystem.Items.Weapon;
using Xunit;

namespace InventorySystem.Tests;

public class WeaponEnchantmentsTests
{
    [Fact]
    public void AddEnchantment_ChangeDamageType()
    {
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .Build();
        
        weapon.AddEnchantment(new FireEnchantment());

        Assert.Equal(DamageType.Fire, weapon.DamageType);
    }

    [Fact]
    public void AddEnchantment_TwoTimes_ChangeDamageTypeToSecond()
    {
        var weapon = new WeaponBuilder()
            .WithName("Sword")
            .Build();
        
        weapon.AddEnchantment(new FireEnchantment());
        weapon.AddEnchantment(new IceEnchantment());

        Assert.Equal(DamageType.Ice, weapon.DamageType);
    }
}

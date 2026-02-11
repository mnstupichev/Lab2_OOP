using Lab2_OOP.Enchantments;
using Lab2_OOP.Items.Weapon;

namespace Lab2_OOP.Tests;

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

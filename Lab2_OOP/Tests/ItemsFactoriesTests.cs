using Lab2_OOP.Items.Armor;
using Lab2_OOP.Items.Food;
using Lab2_OOP.Items.Poison;
using Lab2_OOP.Items.Weapon;

namespace Lab2_OOP.Tests;

public class ItemsFactoriesTests
{
    [Fact]
    public void PotionFactory_CreateItem_ReturnsPotion()
    {
        var factory = new PotionFactory();

        var item = factory.CreateItem();
        
        Assert.IsType<Potion>(item);
    }
    
    [Fact]
    public void FoodFactory_CreateItem_ReturnsFood()
    {
        var factory = new FoodFactory();

        var item = factory.CreateItem();
        
        Assert.IsType<Food>(item);
    }
    
    [Fact]
    public void WeaponFactory_CreateItem_ReturnsWeapon()
    {
        var factory = new WeaponFactory();

        var item = factory.CreateItem();
        
        Assert.IsType<Weapon>(item);
    }
    
    [Fact]
    public void ArmorFactory_CreateItem_ReturnsArmor()
    {
        var factory = new ArmorFactory();

        var item = factory.CreateItem();
        
        Assert.IsType<Armor>(item);
    }
}
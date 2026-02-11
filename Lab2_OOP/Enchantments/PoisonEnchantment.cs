using Lab2_OOP.Items.Weapon;

namespace Lab2_OOP.Enchantments;


public class PoisonEnchantment : IEnchantment
{
public DamageType ChangeDamageType()
    {
        return DamageType.Poison;
    }
}

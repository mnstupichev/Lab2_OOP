using Lab2_OOP.Services.UseServise;

namespace Lab2_OOP.Items.Poison;

public class Potion : BaseItem.BaseItem, IUsable
{
    public PotionEffect Effect { get; private set; }
    public int Potency { get; private set; }

    public Potion(
        string name,
        int quantity,
        PotionEffect effect,
        int potency)
        : base(name, quantity)
    {
        Effect = effect;
        Potency = potency;
    }
    
    public UseResult Use()
    {
        if (Quantity == 0)
        {
            return new UseResult.Failure();
        }

        Quantity--;
        return new UseResult.Success();
    }
}

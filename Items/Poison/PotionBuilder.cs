namespace InventorySystem.Items.Poison;

public class PotionBuilder : IPotionBuilder
{
    private string _name = "Potion";
    private PotionEffect _effect = PotionEffect.Health;
    private int _potency = 50;
    private int _quantity = 1;

    public IPotionBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPotionBuilder WithEffect(PotionEffect effect)
    {
        _effect = effect;
        return this;
    }

    public IPotionBuilder WithPotency(int potency)
    {
        _potency = Math.Max(0, potency);
        return this;
    }

    public IPotionBuilder WithQuantity(int quantity)
    {
        _quantity = Math.Max(1, quantity);
        return this;
    }

    public Potion Build()
    {
        var potion = new Potion(
            name: _name,
            quantity: _quantity,
            effect: _effect,
            potency: _potency
        );
        
        return potion;
    }
}

using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;
using InventorySystem.Core.States;

namespace InventorySystem.Builders;

public class PotionBuilder : IPotionBuilder
{
    private static int _potionCounter = 0;
    
    private string _id = string.Empty;
    private string _name = "Unnamed Potion";
    private string _description = "A potion";
    private PotionEffect _effect = PotionEffect.Health;
    private int _potency = 50;
    private int _quantity = 1;
    private IItemState? _state;

    public IPotionBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPotionBuilder WithDescription(string description)
    {
        _description = description;
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

    public IPotionBuilder WithState(IItemState state)
    {
        _state = state;
        return this;
    }

    public Potion Build()
    {
        if (string.IsNullOrEmpty(_id))
        {
            _id = $"POTION_{++_potionCounter}";
        }

        var potion = new Potion(
            id: _id,
            name: _name,
            description: _description,
            quantity: _quantity,
            effect: _effect,
            potency: _potency
        );

        potion.State = _state ?? new NormalItemState();

        return potion;
    }
}

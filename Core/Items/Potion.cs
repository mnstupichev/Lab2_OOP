using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

/// <summary>
/// Класс зелья.
/// Реализует IUsable для возможности использования.
/// </summary>
public class Potion : BaseItem, IUsable
{
    public PotionEffect Effect { get; private set; }
    public int Potency { get; private set; }
    public int Quatity { get; private set; }

    public Potion(
        string id,
        string name,
        string description,
        int quantity,
        PotionEffect effect,
        int potency)
        : base(id, name, description, quantity)
    {
        Effect = effect;
        Potency = potency;
        Quatity = quantity;
    }

    public bool CanUse => Quatity > 0 && (State?.CanUse ?? true);

    public UseResult Use()
    {
        if (!CanUse)
        {
            return new UseResult
            {
                Success = false,
            };
        }

        Quatity--;
        var modifier = State?.StatModifier ?? 1.0;
        var effectivePotency = (int)(Potency * modifier);

        return new UseResult
        {
            Success = true,
            Message = $"Used {Name}. Effect: {Effect} ({effectivePotency})",
            Effects = new Dictionary<string, object>
            {
                { "Effect", Effect.ToString() },
                { "Potency", effectivePotency }
            }
        };
    }
}

/// <summary>
/// Эффект зелья
/// </summary>
public enum PotionEffect
{
    Health,     // Восстановление здоровья
    FireProtection,       // Защита от огня
    Strength,  // Увеличение силы
    Speed,      // Увеличение скорости
    Invisibility // Невидимость
}

using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Factories;

/// <summary>
/// Фабрика для создания брони.
/// </summary>
public class ArmorFactory : IItemFactory
{
    private static int _armorCounter = 0;

    public IItem CreateItem(string name)
    {
        var id = $"ARMOR_{++_armorCounter}";
        var (defense, quantity, durability) = GetArmorStats(name); // Changed from weight to quantity
        
        var armor = new Armor(
            id: id,
            name: name,
            description: $"An armor that provides {defense} defense",
            quantity: quantity,
            baseDefense: defense,
            durability: durability
        );

        armor.State = new Core.States.NormalItemState();
        
        return armor;
    }

    private (int defense, int quantity, int durability) GetArmorStats(string name) // Changed from weight to quantity
    {
        var baseDefense = 1; // Средняя защита по умолчанию

        var quantity = 1; // Среднее количество по умолчанию

        var durability = 100; // Стандартная прочность

        return (baseDefense, quantity, durability);
    }
}

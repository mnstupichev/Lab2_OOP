using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Factories;

public class ArmorFactory : IItemFactory
{
    private static int _armorCounter = 0;

    public IItem CreateItem(string name)
    {
        var id = $"ARMOR_{++_armorCounter}";
        var defense = 1;
        var quantity = 1;
        var durability = 100;
        
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
}

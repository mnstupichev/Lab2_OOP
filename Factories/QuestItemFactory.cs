using InventorySystem.Core.Interfaces;
using InventorySystem.Core.Items;

namespace InventorySystem.Factories;

/// <summary>
/// Фабрика для создания квестовых предметов.
/// </summary>
public class QuestItemFactory : IItemFactory
{
    private static int _questItemCounter = 0;

    public IItem CreateItem(string name)
    {
        var id = $"QUEST_{++_questItemCounter}";
        var questId = $"QUEST_{name.Replace(" ", "_").ToUpper()}";
        
        var questItem = new QuestItem(
            id: id,
            name: name,
            description: $"A quest item related to {questId}",
            quantity: 1,
            questId: questId
        );

        questItem.State = new Core.States.NormalItemState();
        
        return questItem;
    }
}

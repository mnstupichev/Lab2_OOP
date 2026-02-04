using InventorySystem.Core.Interfaces;

namespace InventorySystem.Core.Items;

/// <summary>
/// Класс квестового предмета.
/// Не реализует IUsable или IEquippable, так как квестовые предметы обычно нельзя использовать или экипировать.
/// Принцип Interface Segregation: не заставляем предмет реализовывать интерфейсы, которые ему не нужны.
/// </summary>
public class QuestItem : BaseItem
{
    public string QuestId { get; private set; }
    public bool IsQuestCompleted { get; set; }

    public QuestItem(
        string id,
        string name,
        string description,
        int quantity,
        string questId)
        : base(id, name, description, quantity)
    {
        QuestId = questId;
        IsQuestCompleted = false;
    }
}

namespace Lab2_OOP.InventoryFolder.Results;

public abstract class AddItemResult
{
    private AddItemResult() { }

    public sealed class Success : AddItemResult;
    
    public sealed class AlreadyFull : AddItemResult;
    
    public sealed class NotEnoughtPlace : AddItemResult;
}
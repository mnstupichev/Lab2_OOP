namespace InventorySystem.InventoryFolder.Results;

public abstract class RemoveResult
{
    private RemoveResult() { }

    public sealed class Success : RemoveResult;
    
    public sealed class Failure : RemoveResult;
}
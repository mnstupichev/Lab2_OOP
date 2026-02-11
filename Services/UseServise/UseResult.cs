namespace InventorySystem.Services.UseServise;

public abstract class UseResult
{
    private UseResult() { }

    public sealed class Success : UseResult;
    
    public sealed class Failure : UseResult;
}
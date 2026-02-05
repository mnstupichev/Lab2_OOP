using Xunit;
using InventorySystem.Services;
using InventorySystem.Builders;
using InventorySystem.States;

namespace InventorySystem.Tests;

public class OverloadedInventoryStateTests
{
    [Fact]
    public void OverloadedState_CanAddItem_AlwaysReturnsFalse()
    {
        var state = new OverloadedInventoryState();
        var weapon = new WeaponBuilder()
            .WithQuantity(10)
            .Build();

        var result = state.CanAddItem(weapon, 50, 100);

        Assert.False(result);
    }

    [Fact]
    public void OverloadedState_CanRemoveItem_ReturnsTrue()
    {
        var state = new OverloadedInventoryState();

        var result = state.CanRemoveItem();

        Assert.True(result);
    }

    [Fact]
    public void OverloadedState_Transition_ToNormalWhenUnderCapacity()
    {
        var state = new OverloadedInventoryState();

        var newState = state.Transition(50, 100);

        Assert.NotNull(newState);
        Assert.IsType<NormalInventoryState>(newState);
    }

    [Fact]
    public void OverloadedState_Transition_StaysOverloadedWhenOverCapacity()
    {
        var state = new OverloadedInventoryState();

        var newState = state.Transition(120, 100);

        Assert.Null(newState);
    }

    [Fact]
    public void NormalState_Transition_ToOverloadedWhenExceedsCapacity()
    {
        var state = new NormalInventoryState();

        var newState = state.Transition(110, 100);

        Assert.NotNull(newState);
        Assert.IsType<OverloadedInventoryState>(newState);
    }

    [Fact]
    public void NormalState_Transition_StaysNormalWhenUnderCapacity()
    {
        var state = new NormalInventoryState();

        var newState = state.Transition(50, 100);

        Assert.Null(newState);
    }

    [Fact]
    public void NormalState_CanAddItem_TrueWhenWithinCapacity()
    {
        var state = new NormalInventoryState();
        var weapon = new WeaponBuilder()
            .WithQuantity(30)
            .Build();

        var result = state.CanAddItem(weapon, 50, 100);

        Assert.True(result);
    }

    [Fact]
    public void NormalState_CanAddItem_FalseWhenExceedsCapacity()
    {
        var state = new NormalInventoryState();
        var weapon = new WeaponBuilder()
            .WithQuantity(60)
            .Build();

        var result = state.CanAddItem(weapon, 50, 100);

        Assert.False(result);
    }

    [Fact]
    public void NormalState_CanRemoveItem_ReturnsTrue()
    {
        var state = new NormalInventoryState();

        var result = state.CanRemoveItem();

        Assert.True(result);
    }
}

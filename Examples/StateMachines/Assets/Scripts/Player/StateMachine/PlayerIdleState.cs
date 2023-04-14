using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    // The constructor of each concrete state will call the parent's constructor
    // using the `: base()` syntax, passing the argument's directly to keep track
    // of the context and the state factory in the base constructor.
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Entered the IDLE state.");
    }

    public override void UpdateState()
    {
        // Update methods for each state will check whether they should
        // transition to another state.
        CheckSwitchStates();
    }

    public override void ExitState()
    {

    }

    public override void OnGUIState()
    {

    }

    public override void CheckSwitchStates()
    {

    }

    public override void InitSubState()
    {

    }
}

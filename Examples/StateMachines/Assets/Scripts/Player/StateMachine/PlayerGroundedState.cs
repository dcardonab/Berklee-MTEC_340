using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        IsRootState = true;

        InitSubState();

        Debug.Log("Entered the GROUNDED state.");
    }

    public override void UpdateState()
    {
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

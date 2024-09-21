// STATE MACHINE - CONCRETE STATE

using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyAliveState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy.IsAlive = true;

        Debug.Log("ENEMY ALIVE state - Enter");
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
        Debug.Log("ENEMY ALIVE state - Update");
        enemy.WanderingAI.Wander();
    }

    public override void ExitState(EnemyStateMachine enemy)
    {
        Debug.Log("ENEMY ALIVE state - Exit");
        enemy.IsAlive = false;
    }
}

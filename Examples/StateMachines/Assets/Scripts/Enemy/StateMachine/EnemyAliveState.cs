// STATE MACHINE - CONCRETE STATE

using UnityEngine;

public class EnemyAliveState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy.IsAlive = true;

        Debug.Log("ENEMY entered the ALIVE state");
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
        enemy.WanderingAI.Wander();
    }
}

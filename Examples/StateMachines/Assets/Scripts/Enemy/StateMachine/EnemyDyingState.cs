// STATE MACHINE - CONCRETE STATE

using UnityEngine;

public class EnemyDyingState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy.ReactiveTarget.ReactToHit();

        Debug.Log("ENEMY entered the DYING state - Enter");
    }

    public override void UpdateState(EnemyStateMachine enemy) {
        Debug.Log("ENEMY entered the DYING state - Update");
    }
}

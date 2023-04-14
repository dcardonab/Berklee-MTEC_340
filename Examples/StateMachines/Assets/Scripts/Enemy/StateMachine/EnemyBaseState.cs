// STATE MACHINE - ABSTRACT STATE

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateMachine enemy);

    public abstract void UpdateState(EnemyStateMachine enemy);
}

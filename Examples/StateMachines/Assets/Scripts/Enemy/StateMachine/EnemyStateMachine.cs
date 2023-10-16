// STATE MACHINE - CONTEXT

using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    // Reference to the currently active state
    EnemyBaseState _currentState;

    // Initialization of each possible state
    public EnemyAliveState AliveState = new();
    public EnemyDyingState DyingState = new();

    bool _isAlive;
    public bool IsAlive { get => _isAlive; set { _isAlive = value;  } }

    // Components that will handle essential behavior of the GameObject
    public ReactiveTarget ReactiveTarget;
    public WanderingAI WanderingAI;

    private void Awake()
    {
        // Retrieve components
        ReactiveTarget = GetComponent<ReactiveTarget>();
        WanderingAI = GetComponent<WanderingAI>();
    }

    private void Start()
    {
        // Initialize state
        SetState(AliveState);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    /// <summary>
    /// Switch to a new state. Each CONCRETE state of the state machine
    /// requires access to the context, which is passed to each state using
    /// the `this` keyword.
    /// </summary>
    /// <param name="newState"></param>
    public void SetState(EnemyBaseState newState)
    {
        _currentState = newState;
        _currentState.EnterState(this);
    }

    public void ReactToHit()
    {
        IsAlive = false;
        SetState(DyingState);
    }
}

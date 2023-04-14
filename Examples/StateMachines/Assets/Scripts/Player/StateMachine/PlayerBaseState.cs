/*
 * Abstract/Base State
 * 
 * The base state is an abstract class from which all other states
 * will be derived. This state doesn't inherit from MonoBehaviour.
 * 
 * Abstract classes aren't directly instantiated, but rather sever
 * as blueprints upon which other classes will be based upon.
 * Declaring an abstract class requires using the `abstract` keyword
 * after the access modifier.
 * 
 * Derived states will be inheriting from this class.
 */
public abstract class PlayerBaseState
{
    // Used to keep track of which state is the root state and which states
    // are substates.
    private bool _isRootState = false;
    protected bool IsRootState { set { _isRootState = value; } }

    // Variables to keep track of the context and the state factory.
    // Note that protected access modifiers on variables and methods allow
    // derived classes to access them.
    private PlayerStateMachine _ctx;
    protected PlayerStateMachine Ctx { get => _ctx;  }

    private PlayerStateFactory _factory;
    protected PlayerStateFactory Factory { get => _factory; }

    private PlayerBaseState _currentSubState;
    private PlayerBaseState _currentSuperState;

    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    {
        _ctx = currentContext;
        _factory = playerStateFactory;
    }

    /*
     * These functions outline the possible function declarations
     * of each derived state. The abstract base class won't have a
     * strict definition for these functions, but just a name that will
     * be defined in each derived class. For this, the abstract keyword
     * must be specified at each function declaration, which will require
     * defining the functionality in each derived state. Each function
     * generally requires the context to have access to the data related
     * to the player, but in this case we are leveraging that using a
     * state factory class, which has a reference to the context.
     * 
     * Note that abstract methods cannot be private, meaning that they
     * require a public access modifier.
     */

    public abstract void EnterState();

    public abstract void UpdateState();

    // Note that if there are exit states for substates, it is possible to
    // implement the a similar logic to UpdateStates().
    public abstract void ExitState();

    public abstract void OnGUIState();

    public abstract void CheckSwitchStates();

    public abstract void InitSubState();

    /******************* STATE MACHINE METHODS *******************/

    /// <summary>
    /// Handle the Update function for both the current state and its substates.
    /// </summary>
    public void UpdateStates()
    {
        // Call the current super state Update .
        UpdateState();

        // Call the sub state Update function.
        if (_currentSubState != null)
            _currentSubState.UpdateState();
    }

    /// <summary>
    /// Transitions to other states can be handled with this method.
    /// Given that the declared parameter is the base state, arguments can
    /// be any state concrete state that is derived from the specified base
    /// state.This function will be called from other concrete states, which
    /// requires its access modifier to be public.
    /// </summary>
    protected void SwitchState(PlayerBaseState newState)
    {
        // The current state will perform the logic defined in its ExitState.
        ExitState();

        // Call the Enter State function of the newly selected state.
        newState.EnterState();

        // Update the current state in the context if it is a root state.
        if (_isRootState)
            _ctx.CurrentState = newState;

        // Otherwise, check if the current state has a super state, and if it
        // does, set that super state's sub state to the new state. This
        // transfers the super state over to the next state.
        else if (_currentSuperState != null)
            _currentSuperState.SetSubState(newState);
    }

    protected void SetSuperState(PlayerBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState)
    {
        _currentSubState = newSubState;

        // A substate will be a child of the super state. With this line
        // we are also creating the inverse, allowing for a bidirectional
        // relationship between super and sub states.
        newSubState.SetSuperState(this);
    }
}

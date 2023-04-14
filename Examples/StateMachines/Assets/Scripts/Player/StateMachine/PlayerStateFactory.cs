/*
 * State Factory
 * 
 * Creates the concrete states from within the context.
 */
public class PlayerStateFactory
{
    PlayerStateMachine _context;

    /// <summary>
    /// Constructor is used to allow the StateFactory to hold a reference to
    /// the state machine.
    /// </summary>
    /// <param name="currentContext"></param>
    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    /*
     * Methods for each concrete state.
     * Each returns an instance of their respective concrete state.
     * Also, each concrete state will be given access to the context,
     * and to the factory itself, which is essential for switching to
     * other states.
     */
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }

    public PlayerBaseState Walk()
    {
        return new PlayerWalkState(_context, this);
    }
    public PlayerBaseState Run()
    {
        return new PlayerRunState(_context, this);
    }

    public PlayerBaseState Grounded()
    {
        return new PlayerGroundedState(_context, this);
    }

    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(_context, this);
    }
}

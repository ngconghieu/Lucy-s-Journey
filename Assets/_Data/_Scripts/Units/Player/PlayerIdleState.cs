public class PlayerIdleState : BaseState<PlayerState, Player>
{
    private readonly IInputProvider _input;
    public PlayerIdleState(Player owner, IInputProvider input) : base(owner)
    {
        _input = input;
    }

    public override void Enter()
    {
        //Debug.Log("PlayerIdleState Enter");
    }

    public override void Exit()
    {
        //Debug.Log("PlayerIdleState Exit");
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
        if (_input.RunHorizontal != 0)
        {
            Owner.StateMachine.ChangeState(PlayerState.Run);
        }
    }

}
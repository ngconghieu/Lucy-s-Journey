public class PlayerIdleState : BaseState<PlayerState>
{
    private readonly IInputProvider _input;
    private readonly Player _player;

    public PlayerIdleState(PlayerState owner, Player player, IInputProvider input) : base(owner)
    {
        _input = input;
        _player = player;
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
            _player.StateMachine.ChangeState(PlayerState.Run);
        }
    }

}
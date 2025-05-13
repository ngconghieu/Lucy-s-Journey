using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerState>
{
    private IInputProvider _inputProvider;
    private Player _player;

    protected override void Start()
    {
        _inputProvider = ServiceLocator.Get<IInputProvider>();
        _inputProvider.OnJump += HandleJump;
        _inputProvider.OnDash += HandleDash;
        base.Start();
    }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void OnDisable()
    {
        _inputProvider.OnDash -= HandleDash;
        _inputProvider.OnJump -= HandleJump;
    }

    private void HandleDash()
    {
        if(currentState is not PlayerDashState)
            ChangeState(PlayerState.Dash);
    }

    private void HandleJump()
    {
        if (currentState is not PlayerJumpState)
            ChangeState(PlayerState.Jump);
    }

    protected override void LoadStates()
    {
        states.Add(PlayerState.Idle, new PlayerIdleState(PlayerState.Idle, _player, _inputProvider));
        states.Add(PlayerState.Run, new PlayerRunState(PlayerState.Run, _player, _inputProvider));
        states.Add(PlayerState.Jump, new PlayerJumpState(PlayerState.Jump, _player));
        states.Add(PlayerState.Dash, new PlayerDashState(PlayerState.Dash, _player));
        ChangeState(PlayerState.Idle);
    }
}

public enum PlayerState
{
    Idle,
    Run,
    Jump,
    Dash,
    Attack,
    Hurt,
    Dead
}
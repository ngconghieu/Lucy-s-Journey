using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerState, Player>
{
    private IInputProvider _inputProvider;

    protected override void Start()
    {
        _inputProvider = ServiceLocator.Get<IInputProvider>();
        _inputProvider.OnJump += HandleJump;
        _inputProvider.OnDash += HandleDash;
        base.Start();
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

    protected override void LoadState()
    {
        states.Add(PlayerState.Idle, new PlayerIdleState(unit, _inputProvider));
        states.Add(PlayerState.Run, new PlayerRunState(unit, _inputProvider));
        states.Add(PlayerState.Jump, new PlayerJumpState(unit, _inputProvider));
        states.Add(PlayerState.Dash, new PlayerDashState(unit, _inputProvider));
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
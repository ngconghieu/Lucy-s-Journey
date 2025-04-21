public class PlayerStateMachine : StateMachine<PlayerState, Player>
{
    private void OnEnable()
    {
        InputManager.Instance.OnDash += HandleDash;
        InputManager.Instance.OnJump += HandleJump;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnDash -= HandleDash;
        InputManager.Instance.OnJump -= HandleJump;
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
        states.Add(PlayerState.Idle, new PlayerIdleState(unit));
        states.Add(PlayerState.Run, new PlayerRunState(unit));
        states.Add(PlayerState.Jump, new PlayerJumpState(unit));
        states.Add(PlayerState.Dash, new PlayerDashState(unit));
        currentState = states[PlayerState.Idle];
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
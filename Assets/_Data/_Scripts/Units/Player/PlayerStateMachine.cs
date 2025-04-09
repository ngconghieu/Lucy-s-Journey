public class PlayerStateMachine : StateMachine<PlayerState, Player>
{
    protected override void LoadState()
    {
        states.Add(PlayerState.Idle, new PlayerIdleState(unit));
        states.Add(PlayerState.Run, new PlayerRunState(unit));
        states.Add(PlayerState.Jump, new PlayerJumpState(unit));
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
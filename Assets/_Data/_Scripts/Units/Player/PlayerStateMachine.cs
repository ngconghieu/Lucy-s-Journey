using System;
using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerState>
{
    public IInputProvider InputProvider { get; private set; }
    public Player Player { get; private set; }
    private bool _isGrounded;
    

    protected void Start()
    {
        InputProvider = ServiceLocator.Get<IInputProvider>();
        InputProvider.OnJump += HandleJump;
        //_inputProvider.OnDash += HandleDash;
        LoadStates();
    }

    protected override void Update()
    {
        base.Update();

        Debug.Log(currentState);

        // update grounded state
        if (_isGrounded)
        {
            if (InputProvider.MoveInput == 0)
            {
                if (currentState != states[PlayerState.Idle] && currentState.IsCompleted)
                    SelectState(PlayerState.Idle);
            }
            else
            {
                if (currentState != states[PlayerState.Run] && currentState.IsCompleted)
                    SelectState(PlayerState.Run);
            }
        }
        else
        {
            if (currentState != states[PlayerState.Jump] && currentState.IsCompleted)
                SelectState(PlayerState.Jump);
        }
    }

    public void Setup(Player player)
    {
        Player = player;
    }

    private void OnDisable()
    {
        InputProvider.OnDash -= HandleDash;
        InputProvider.OnJump -= HandleJump;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        _isGrounded = Player.GroundSensor.IsGrounded;
    }

    private void HandleDash()
    {
        
    }

    private void HandleJump()
    {
        if (currentState != states[PlayerState.Jump])
        {
            Player.Rigibody.AddForce(Vector2.up * Player.PlayerStats.JumpForce, ForceMode2D.Impulse);
            if (_isGrounded && currentState.IsCompleted)
            {
                SelectState(PlayerState.Jump);
            }
        }
    }

    protected void LoadStates()
    {
        AddState(PlayerState.Idle, new PlayerIdleState());
        AddState(PlayerState.Run, new PlayerRunState(Player, Player.PlayerStats.Speed, InputProvider));
        AddState(PlayerState.Jump, new PlayerJumpState(Player, Player.PlayerStats.Speed, InputProvider));
        //AddState(PlayerState.Fall, new PlayerFallState(Player));
        //states.Add(PlayerState.Dash, new PlayerDashState(PlayerState.Dash, _player));
        SelectState(PlayerState.Idle);
    }
}

public enum PlayerState
{
    Idle,
    Run,
    Jump,
    Fall,
    Dash,
    Attack,
    Hurt,
    Dead,
    Ground,
    Air
}
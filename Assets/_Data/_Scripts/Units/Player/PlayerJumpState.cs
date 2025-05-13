using UnityEngine;

public class PlayerJumpState : BaseState<PlayerState>
{
    private readonly Player _player;
    private Rigidbody2D _rb;

    public PlayerJumpState(PlayerState owner, Player player) : base(owner)
    {
        _player = player;
    }

    public override void Enter()
    {
        //Debug.Log("PlayerJumpState Enter");
        _rb = _player.Rigibody;
        _rb.AddForce(Vector2.up * _player.PlayerStats.jumpForce, ForceMode2D.Impulse);
        _player.Anim.SetBool(Const.AnimGround, false);
        _player.Anim.SetTrigger(Const.AnimJump);
    }

    public override void Exit()
    {
        //Debug.Log("PlayerJumpState Exit");
        _player.Anim.SetBool(Const.AnimGround, true);
    }

    public override void FixedUpdate()
    {
        _player.Anim.SetFloat(Const.AnimVelocityY, _rb.linearVelocityY);

        if (_rb.linearVelocityY == 0) 
            _player.StateMachine.ChangeState(PlayerState.Idle);
        

    }

    public override void Update()
    {
    }
}
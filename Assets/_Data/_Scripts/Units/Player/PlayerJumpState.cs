using UnityEngine;

public class PlayerJumpState : BaseState<PlayerState, Player>
{
    private Rigidbody2D _rb;
    public PlayerJumpState(Player owner, IInputProvider input) : base(owner)
    {
    }

    public override void Enter()
    {
        //Debug.Log("PlayerJumpState Enter");
        _rb = Owner.Rigibody;
        _rb.AddForce(Vector2.up * Owner.PlayerStats.jumpForce, ForceMode2D.Impulse);
        Owner.Anim.SetBool(Const.AnimGround, false);
        Owner.Anim.SetTrigger(Const.AnimJump);
    }

    public override void Exit()
    {
        //Debug.Log("PlayerJumpState Exit");
        Owner.Anim.SetBool(Const.AnimGround, true);
    }

    public override void FixedUpdate()
    {
        Owner.Anim.SetFloat(Const.AnimVelocityY, _rb.linearVelocityY);

        if (_rb.linearVelocityY == 0) 
            Owner.StateMachine.ChangeState(PlayerState.Idle);
        

    }

    public override void Update()
    {
    }
}
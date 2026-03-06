using System;
using UnityEngine;

public class PlayerJumpState : PlayerMovementState
{
    public PlayerJumpState(IUnitBase unit, float speed, IInputProvider input) : base(unit, speed, input)
    {
    }

    public override void Enter()
    {
        //Debug.Log("PlayerJumpState Enter");
        _unit.Anim.SetBool(Const.AnimGround, false);
        _unit.Anim.SetTrigger(Const.AnimJump);
        IsCompleted = true;

    }

    public override void Exit()
    {
        //Debug.Log("PlayerJumpState Exit");
        base.Exit();
        _unit.Anim.SetBool(Const.AnimGround, true);
    }

    public override void FixedDo()
    {
        base.FixedDo();
        _unit.Anim.SetFloat(Const.AnimVelocityY, _unit.Rigibody.linearVelocityY);
    }
}
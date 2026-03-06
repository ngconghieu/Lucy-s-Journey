using System;
using UnityEngine;

public class PlayerRunState : PlayerMovementState
{
    public PlayerRunState(IUnitBase unit, float speed, IInputProvider input) : base(unit, speed, input)
    {
    }

    public override void Enter()
    {
        _unit.Anim.SetBool(Const.AnimRun, true);
        IsCompleted = true;
    }

    public override void Exit()
    {
        base.Exit();
        _unit.Anim.SetBool(Const.AnimRun, false);
    }
}
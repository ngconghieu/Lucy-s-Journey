using System;
using UnityEngine;

public class PlayerRunState : BaseState<PlayerState, Player>
{
    private float _runHorizontal;
    private float _speed;
    public PlayerRunState(Player owner) : base(owner)
    {
    }

    public override void Enter()
    {
        Owner.Anim.SetBool(Const.AnimRun, true);
        _speed = Owner.StateMachine.playerStats.speed;
    }

    public override void Exit()
    {
        Owner.Rigibody.linearVelocityX = 0;
        Owner.Anim.SetBool(Const.AnimRun, false);
    }

    public override void FixedUpdate()
    {
        Rotate();
        Move();
    }

    public override void Update()
    {
        _runHorizontal = InputManager.Instance.RunHorizontal;
        if (_runHorizontal != 0) return;
        Owner.StateMachine.ChangeState(PlayerState.Idle);
    }

    private void Move() =>
        Owner.Rigibody.linearVelocityX = _runHorizontal * _speed;

    private void Rotate() =>
        Owner.transform.rotation = Quaternion.Euler(0, _runHorizontal > 0 ? 0 : 180, 0);
}
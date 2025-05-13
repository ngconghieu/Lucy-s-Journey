using System;
using UnityEngine;

public class PlayerRunState : BaseState<PlayerState>
{
    private readonly IInputProvider _input;
    private readonly Player _player;
    private float _runHorizontal;
    private float _speed;
    public PlayerRunState(PlayerState owner, Player player, IInputProvider input) : base(owner)
    {
        _input = input;
        _player = player;
    }

    public override void Enter()
    {
        _player.Anim.SetBool(Const.AnimRun, true);
        _speed = _player.PlayerStats.speed;
    }

    public override void Exit()
    {
        _player.Rigibody.linearVelocityX = 0;
        _player.Anim.SetBool(Const.AnimRun, false);
    }

    public override void FixedUpdate()
    {
        Rotate();
        Move();
    }

    public override void Update()
    {
        _runHorizontal = _input.RunHorizontal;
        if (_runHorizontal != 0) return;
        _player.StateMachine.ChangeState(PlayerState.Idle);
    }

    private void Move() =>
        _player.Rigibody.linearVelocityX = _runHorizontal * _speed;

    private void Rotate() =>
        _player.transform.rotation = Quaternion.Euler(0, _runHorizontal > 0 ? 0 : 180, 0);
}
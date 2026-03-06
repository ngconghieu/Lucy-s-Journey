using UnityEngine;

public abstract class PlayerMovementState : BaseState
{
    protected readonly IUnitBase _unit;
    protected IInputProvider _input;
    protected float _speed;
    protected float _inputDir = 1;
    protected PlayerMovementState(IUnitBase unit, float speed, IInputProvider input)
    {
        _unit = unit;
        _input = input;
        _speed = speed;
    }

    public override void Do()
    {
        UpdateDirection();
    }

    public override void FixedDo()
    {
        Rotate();
        Move();
    }

    protected void Move() =>
        _unit.Rigibody.linearVelocityX = _inputDir * _speed;

    protected void Rotate() =>
        _unit.Rigibody.transform.rotation = Quaternion.Euler(0, _inputDir == 1 ? 0 : 180, 0);

    protected void UpdateDirection()
    {
        if (_input.MoveInput > 0)
            _inputDir = 1; // facing right
        else if (_input.MoveInput < 0)
            _inputDir = -1; // facing left
    }

    public override void Exit()
    {
        _unit.Rigibody.linearVelocityX = 0;
    }
}
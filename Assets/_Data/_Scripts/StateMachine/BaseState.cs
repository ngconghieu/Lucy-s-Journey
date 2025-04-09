using System;

public abstract class BaseState<T, Base> where T : Enum where Base : UnitBase
{
    public Base Owner { get; }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();
    public BaseState(Base owner)
    {
        Owner = owner;
    }
}
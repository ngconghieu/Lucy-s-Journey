using System;

public abstract class BaseState<T> where T : Enum
{
    public T Owner { get; }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();
    public BaseState(T owner)
    {
        Owner = owner;
    }
}
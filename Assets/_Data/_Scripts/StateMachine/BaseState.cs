public abstract class BaseState
{
    public bool IsCompleted { get; protected set; }

    public abstract void Enter();

    public abstract void Do();

    public abstract void FixedDo();

    public abstract void Exit();

}
public abstract class State<T>
{
    protected T owner;
    public State(T owner)
    {
        this.owner = owner;
    }

    public abstract void EnterState();
    public abstract void ExecuteState();
    public abstract void ExitState();
}
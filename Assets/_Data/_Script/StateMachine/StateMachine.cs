public class StateMachine<T>
{
    private T owner;
    public State<T> currentState;
    public StateMachine(T owner)
    {
        this.owner = owner;
    }

    public void ChangeState(State<T> newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState?.EnterState();
    }

    public void ExecuteState()
    {
        currentState?.ExecuteState();
    }
}
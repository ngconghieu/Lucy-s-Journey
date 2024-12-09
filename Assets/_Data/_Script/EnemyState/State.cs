using UnityEngine;

public abstract class State
{
    protected GameObject state;
    public State(GameObject state) {
        this.state = state;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}

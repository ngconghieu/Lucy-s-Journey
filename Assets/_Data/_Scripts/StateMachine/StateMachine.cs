using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T> : BaseMonoBehaviour where T : Enum
{
    protected Dictionary<T, BaseState<T>> states = new();
    protected BaseState<T> currentState;

    protected virtual void Start()
    {
        LoadStates();
    }

    protected void Update()
    {
        currentState?.Update();
    }

    protected void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    public void ChangeState(T nextStateKey)
    {
        if (!states.ContainsKey(nextStateKey))
            Debug.LogError($"State {nextStateKey} not found", gameObject);
        currentState?.Exit();
        currentState = states[nextStateKey];
        currentState.Enter();
    }

    protected abstract void LoadStates();
}

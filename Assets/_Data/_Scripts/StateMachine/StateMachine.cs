using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> : BaseMonoBehaviour where T : Enum
{
    protected Dictionary<T, BaseState> states = new();
    public BaseState currentState;

    protected virtual void Update()
    {
        currentState?.Do();
    }

    protected virtual void FixedUpdate()
    {
        currentState?.FixedDo();
    }

    public void SelectState(T nextStateKey)
    {
        if (!states.ContainsKey(nextStateKey))
            Debug.LogError($"State {nextStateKey} not found");
        currentState?.Exit();
        currentState = states[nextStateKey];
        currentState.Enter();
    }

    public void AddState(T key, BaseState state)
    {
        if (states.ContainsKey(key))
            Debug.LogError($"State {key} already exists");
        states.Add(key, state);
    }
}

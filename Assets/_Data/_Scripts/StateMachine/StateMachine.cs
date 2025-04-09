using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T, Base> : BaseMonoBehaviour where T : Enum where Base : UnitBase
{
    public PlayerStats playerStats;
    protected Dictionary<T, BaseState<T, Base>> states = new();
    protected BaseState<T, Base> currentState;
    protected Base unit;

    public void Initialize(Base unit)
    {
        this.unit = unit;
        LoadState();
        currentState?.Enter();
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
            Debug.LogError($"State {nextStateKey} not found in state machine of {unit.name}");
        currentState?.Exit();
        currentState = states[nextStateKey];
        currentState.Enter();
    }

    protected abstract void LoadState();
}

[Serializable]
public struct PlayerStats
{
    public float speed;
    public float jumpForce;
    public float jumpTime;
    public float jumpHeight;
    public float fallSpeed;
    public float maxFallSpeed;
    public float maxJumpTime;
}
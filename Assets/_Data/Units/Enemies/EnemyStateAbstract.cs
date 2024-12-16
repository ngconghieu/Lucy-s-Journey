using System;
using UnityEngine;

public abstract class EnemyStateAbstract : GameMonoBehaviour
{
    public StateMachine<EnemyStateAbstract> StateMachine { get; private set; }

    protected override void Start()
    {
        base.Start();
        StateMachine = new StateMachine<EnemyStateAbstract>(this);

        //set start state
        StateMachine.ChangeState(StartState());
    }

    protected virtual void Update()
    {
        StateMachine.ExecuteState();
    }

    public abstract State<EnemyStateAbstract> StartState();
}

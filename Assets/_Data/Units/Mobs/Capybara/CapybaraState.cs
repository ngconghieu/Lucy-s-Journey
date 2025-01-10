using System;
using UnityEngine;

public class CapybaraState : CapybaraAbstract
{
    public StateMachine<CapybaraState> StateMachine { get; private set; }

    [Header("Walk State")]
    public float walkingTime = 4f;
    public bool canMove; //Check on animation

    [Header("Dead State")]
    public float cdToDespawn = 3f;
    public int dropItemCnt = 1;

    protected override void Start()
    {
        base.Start();
        StateMachine = new StateMachine<CapybaraState>(this);

        InitializeStats();

        SubscribeEvents();

        //Start state
        StateMachine.ChangeState(GetIdleState());
    }

    private void InitializeStats()
    {
        CapybaraCtrl.DmgReceiver.SetMaxHp(CapybaraCtrl.EnemiesSO.hpMax);
        CapybaraCtrl.DmgReceiver.Reborn();
    }

    protected virtual void SubscribeEvents()
    {
        CapybaraCtrl.DmgReceiver.OnDead += HandleDead;
    }

    protected virtual void UnsubscribeEvents()
    {
        CapybaraCtrl.DmgReceiver.OnDead -= HandleDead;
    }

    protected virtual void Update()
    {
        StateMachine.ExecuteState();
        if(CapybaraCtrl.dead)
        {
            if (StateMachine.currentState is not CapybaraDeadState)
                StateMachine.ChangeState(GetDeadState());
        }
        //if (canMove && !CapybaraCtrl.dead)
        //    if (StateMachine.currentState != GetWalkState())
        //        StateMachine.ChangeState(GetWalkState());
    }

    protected override void OnDisable()
    {
        UnsubscribeEvents();
    }

    protected virtual void HandleDead()
    {
        CapybaraCtrl.dead = true;
        if (StateMachine.currentState != GetDeadState())
            StateMachine.ChangeState(GetDeadState());
    }

    public State<CapybaraState> GetIdleState() => new CapybaraIdleState(this);
    public State<CapybaraState> GetWalkState() => new CapybaraWalkState(this);
    public State<CapybaraState> GetDeadState() => new CapybaraDeadState(this);
    public void AnimTriggerDead() => CapybaraCtrl.CapybaraAnim.TriggerDead();
}

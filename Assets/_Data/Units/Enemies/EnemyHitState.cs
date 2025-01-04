using UnityEngine;

public class EnemyHitState : State<EnemyState>
{
    protected float timer;

    public EnemyHitState(EnemyState owner) : base(owner) { }

    public override void EnterState()
    {
        owner.EnemyCtrl.hit = true;
        timer = 0;
        OnEnterState();
    }

    public override void ExecuteState()
    {
        timer += Time.deltaTime;
        if (timer > owner.delayWhenReceivedDmg)
            owner.StateMachine.ChangeState(owner.GetChaseState());
    }

    public override void ExitState()
    {
        owner.EnemyCtrl.hit = false;
    }

    protected virtual void OnEnterState()
    {
        //For Override
        owner.AnimTriggerHit();
    }
}
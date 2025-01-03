using UnityEngine;

public abstract class EnemyReceivedDmgState<T> : State<T> where T : EnemyState
{
    protected float timer;

    public EnemyReceivedDmgState(T owner) : base(owner) { }

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
            owner.StateMachine.ChangeState(owner.GetStartState());
    }

    public override void ExitState()
    {
        owner.EnemyCtrl.hit = false;
    }

    protected abstract void OnEnterState();
}
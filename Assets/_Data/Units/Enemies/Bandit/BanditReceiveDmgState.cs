using UnityEngine;

public class BanditReceiveDmgState : State<BanditState>
{
    float timer;
    public BanditReceiveDmgState(BanditState owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        owner.BanditCtrl.hit = true;
        timer = 0;
        owner.BanditCtrl.BanditAnim.TriggerHit();
    }

    public override void ExecuteState()
    {
        timer += Time.deltaTime;
        if (timer > owner.delayWhenReceivedDmg)
            owner.StateMachine.ChangeState(new BanditChaseState(owner));
    }

    public override void ExitState()
    {
        owner.BanditCtrl.hit = false;
    }
}
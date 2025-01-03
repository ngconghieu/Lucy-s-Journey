using UnityEngine;

public class BanditDeadState : EnemyDeadState<EnemyState>
{
    public BanditDeadState(EnemyState owner) : base(owner)
    {
    }

    protected override void OnEnterState()
    {
        var banditCtrl = owner.EnemyCtrl as BanditCtrl;
        banditCtrl?.BanditAnim.TriggerDead();
    }
}

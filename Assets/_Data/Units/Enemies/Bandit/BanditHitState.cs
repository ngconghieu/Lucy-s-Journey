using UnityEngine;

public class BanditHitState : EnemyHitState
{
    public BanditHitState(EnemyState owner) : base(owner)
    {
    }

    protected override void OnEnterState()
    {
        var banditCtrl = owner.EnemyCtrl as BanditCtrl;
        banditCtrl.BanditAnim.TriggerHit();
    }
}

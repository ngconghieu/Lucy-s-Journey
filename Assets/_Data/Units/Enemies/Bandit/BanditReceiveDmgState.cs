using UnityEngine;

public class BanditReceiveDmgState : EnemyReceivedDmgState<EnemyState>
{
    public BanditReceiveDmgState(EnemyState owner) : base(owner)
    {
    }

    protected override void OnEnterState()
    {
        var banditCtrl = owner.EnemyCtrl as BanditCtrl;
        banditCtrl?.BanditAnim.TriggerHit();
    }
}

using System;
using UnityEngine;

public class BanditState : EnemyState
{
    private BanditCtrl BanditCtrl => enemyCtrl as BanditCtrl;
    public override State<EnemyState> GetCombatState()
    {
        return new EnemyCombatState(this);
    }

    public override State<EnemyState> GetDeadState()
    {
        return new EnemyDeadState(this);
    }

    public override State<EnemyState> GetHitState()
    {
        return new EnemyHitState(this);
    }

    public override State<EnemyState> GetChaseState()
    {
        return new BanditChaseState(this);
    }

    public override void AnimTriggerHit() => BanditCtrl.BanditAnim.TriggerHit();

    public override void AnimTriggerDead() => BanditCtrl.BanditAnim.TriggerDead();

    public override void AnimTriggerAttack() => BanditCtrl.BanditAnim.TriggerAttack();

    public override void AnimTriggerSpecialAttack()
    {
    }
}
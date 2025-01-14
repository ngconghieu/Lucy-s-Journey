using System;
using UnityEngine;

public class HuntressState : EnemyState
{
    HuntressCtrl HuntressCtrl => enemyCtrl as HuntressCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadStats();
    }

    private void LoadStats()
    {
        distanceToAttack = 2.5f;
        specialAttackDelay = 7;
        specialAttackTimer = specialAttackDelay;
    }

    protected override void DetectPlayerInRange()
    {
        enemyCtrl.detectPlayer = enemyCtrl.DetectPlayer.DetectPlayerForFlying(detectPlayerRange, posPlayer);
    }

    public override void AnimTriggerAttack() => HuntressCtrl.HuntressAnim.TriggerAttack();

    public override void AnimTriggerDead() => HuntressCtrl.HuntressAnim.TriggerDead();

    public override void AnimTriggerHit() => HuntressCtrl.HuntressAnim.TriggerHit();

    public override void AnimTriggerSpecialAttack() => HuntressCtrl.HuntressAnim.TriggerSpecialAttack();

    public override State<EnemyState> GetChaseState()
    {
        return new HuntressChaseState(this);
    }

    public override State<EnemyState> GetCombatState()
    {
        return new HuntressCombatState(this);
    }

    public override State<EnemyState> GetDeadState()
    {
        return new EnemyDeadState(this);
    }

    public override State<EnemyState> GetHitState()
    {
        return new EnemyHitState(this);
    }
}

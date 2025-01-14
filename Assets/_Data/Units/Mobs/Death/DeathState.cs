using UnityEngine;

public class DeathState : EnemyState
{
    DeathCtrl DeathCtrl => enemyCtrl as DeathCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadStats();
    }

    private void LoadStats()
    {
        delayHit = 3;
        distanceToAttack = 6f;
        detectPlayerRange = 14f;
        specialAttackDelay = 8;
        specialAttackTimer = specialAttackDelay;
        specialAttackDelay1 = 10;
        specialAttackTimer1 = specialAttackDelay1;
    }

    protected override void HandleHurt(LayerMask layer)
    {
        if (layer == LayerMask.NameToLayer("Player"))
        {
            AnimTriggerHit();
        }
    }

    protected override void DetectPlayerInRange()
    {
        enemyCtrl.detectPlayer = enemyCtrl.DetectPlayer.DetectPlayerForFlying(detectPlayerRange, posPlayer);
    }

    public override void AnimTriggerAttack() => DeathCtrl.DeathAnim.TriggerAttack();

    public override void AnimTriggerDead() => DeathCtrl.DeathAnim.TriggerDead();

    public override void AnimTriggerHit() => DeathCtrl.DeathAnim.TriggerHit();

    public override void AnimTriggerSpecialAttack() => DeathCtrl.DeathAnim.TriggerSpecialAttack();

    public override void AnimTriggerSpecialAttack1() => DeathCtrl.DeathAnim.TriggerSpecialAttack1();

    public override State<EnemyState> GetChaseState()
    {
        return new DeathChaseState(this);
    }

    public override State<EnemyState> GetCombatState()
    {
        return new DeathCombatState(this);
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

using UnityEngine;

public class HuntressState : EnemyState
{
    public override void AnimTriggerAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void AnimTriggerDead()
    {
        throw new System.NotImplementedException();
    }

    public override void AnimTriggerHit()
    {
        
    }

    public override void AnimTriggerSpecialAttack()
    {
        throw new System.NotImplementedException();
    }

    public override State<EnemyState> GetChaseState()
    {
        return new HuntressChaseState(this);
    }

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
}

using UnityEngine;

public class HuntressState : EnemyState
{
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
        return new HuntressDeadState(this);
    }

    public override State<EnemyState> GetHitState()
    {
        return new HuntressHitState(this);
    }
}

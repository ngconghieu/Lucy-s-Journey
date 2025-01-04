using System;
using UnityEngine;

public class BanditState : EnemyState
{
    public override State<EnemyState> GetCombatState()
    {
        return new BanditCombatState(this);
    }

    public override State<EnemyState> GetDeadState()
    {
        return new BanditDeadState(this);
    }

    public override State<EnemyState> GetHitState()
    {
        return new BanditHitState(this);
    }

    public override State<EnemyState> GetChaseState()
    {
        return new BanditChaseState(this);
    }
}
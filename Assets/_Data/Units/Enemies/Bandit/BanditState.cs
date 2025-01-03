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

    public override State<EnemyState> GetReceivedDmgState()
    {
        return new BanditReceiveDmgState(this);
    }

    public override State<EnemyState> GetStartState()
    {
        return new BanditChaseState(this);
    }
}
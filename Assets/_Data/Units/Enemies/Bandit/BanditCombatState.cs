using System;
using UnityEngine;

public class BanditCombatState : EnemyCombatState
{
    public BanditCombatState(EnemyState owner) : base(owner)
    {
    }

    protected override void Attack()
    {
        comboTime++;
        owner.EnemyCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
    }
}

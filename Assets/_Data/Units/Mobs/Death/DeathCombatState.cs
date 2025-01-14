using System;
using UnityEngine;

public class DeathCombatState : EnemyCombatState
{
    bool performed;
    public DeathCombatState(EnemyState owner) : base(owner)
    {
    }
    protected override void Attack()
    {
        if (owner.specialAttackTimer > owner.specialAttackDelay)
        {
            if (!performed)
            {
                performed = true;
                owner.AnimTriggerSpecialAttack();
            }
            if (owner.canPerformSpecialAttack)
                SpawnCellSpell();
        }
        else if (owner.specialAttackTimer1 > owner.specialAttackDelay1 && owner.EnemyCtrl.DetectPlayer.DetectPlayerInArea())
        {
            if (!performed)
            {
                performed = true;
                owner.AnimTriggerSpecialAttack1();
            }
            if (owner.canPerformSpecialAttack1)
                SpawnBallSpell();
        }
        else
        {
            if (owner.distanceToPlayer < owner.distanceToAttack)
                base.Attack();
        }
    }

    private void SpawnBallSpell()
    {
        float dir;
        if (owner.transform.localScale.x < 0)
            dir = 180;
        else 
            dir = 0;
        PrefabSpawner.Instance.Spawn(PrefabSpawner.DeathBallDarkSpell, owner.transform.position, Quaternion.Euler(0,0,dir));
        owner.specialAttackTimer1 = 0;
        comboTime++;
    }

    private void SpawnCellSpell()
    {
        PrefabSpawner.Instance.Spawn(PrefabSpawner.DeathCellDarkSpell, owner.transform.position, Quaternion.Euler(0,0,0));
        owner.specialAttackTimer = 0;
        comboTime++;
    }
}

using UnityEngine;

public class HuntressCombatState : EnemyCombatState
{
    bool performed;
    public HuntressCombatState(EnemyState owner) : base(owner)
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
                SpawnSpear();
        }
        else
            base.Attack();
    }

    private void SpawnSpear()
    {
        Vector3 dis = (owner.posPlayer.transform.position - owner.transform.position).normalized;
        float rot_z = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0, 0, rot_z);
        PrefabSpawner.Instance.Spawn(PrefabSpawner.HuntressSpear, owner.transform.position, rot);
        owner.specialAttackTimer = 0;
        comboTime++;
    }
}
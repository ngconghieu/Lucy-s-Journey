using UnityEngine;

public class HuntressCombatState : EnemyCombatState
{
    public HuntressCombatState(EnemyState owner) : base(owner)
    {
    }
    protected override void Attack()
    {
        if (owner.attackTimer1 > 7)
        {
            comboTime++;
            owner.AnimTriggerSpecialAttack();
            Vector3 dis = (owner.posPlayer.transform.position - owner.transform.position).normalized;
            float rot_z = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, 0, rot_z);
            PrefabSpawner.Instance.Spawn(PrefabSpawner.HuntressSpear, owner.transform.position, rot);
            owner.attackTimer1 = 0;
        }
        base.Attack();
    }
}
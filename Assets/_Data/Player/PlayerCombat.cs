using System;
using UnityEngine;

public class PlayerCombat : PlayerAbstract
{
    [SerializeField] protected Transform attackPoint;
    [SerializeField] float attackRange = 0.3f;
    [SerializeField] LayerMask enemyLayers;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyLayers();
        this.LoadAttackPoint();
    }

    private void LoadAttackPoint()
    {
        if (attackPoint != null) return;
        attackPoint = transform.Find("AttackPoint");
        Debug.LogWarning(transform.name + ": LoadAttackPoint", gameObject);
    }

    private void LoadEnemyLayers()
    {
        enemyLayers = LayerMask.GetMask("Enemy");
    }

    protected virtual void Update()
    {
        this.Attack();
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerCtrl.attack = true;
            playerCtrl.Animator.SetTrigger("Attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log(enemy.name);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

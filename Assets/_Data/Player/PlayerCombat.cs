using System;
using UnityEngine;

public class PlayerCombat : PlayerAbstract
{
    [Header("Setting combat")]
    //[SerializeField] float attackRange = 0.8f;
    //[SerializeField] float attackRate = 1f;
    //float attackCountdown = 0;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] Collider2D atkCollider;

    [Header("Setting send dmg")]
    [SerializeField] protected int dmg = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyLayers();
        LoadAtkCollider();
    }

    private void LoadAtkCollider()
    {
        if (atkCollider != null) return;
        this.atkCollider = transform.parent.Find("Model").GetComponent<Collider2D>();
        Debug.LogWarning(transform.name + ": LoadAtkCollider", gameObject);
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
        if (InputManager.Instance.Attack())
        {
            Attacking();
        }
    }

    //private void Attack()
    //{
    //    if (Input.GetButtonDown("Fire1") && attackCountdown <=Time.time)
    //    {
    //        Attacking();
    //        attackCountdown = Time.time + 1f / attackRate;

    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(transform.name + " " + collision);
    }

    protected virtual void Attacking()
    {
        playerCtrl.PlayerState.Attacking = true;
        playerCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack1);
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    DmgReceiver receiver = enemy.GetComponent<DmgReceiver>();
        //    receiver.Deduct(dmg);
        //}
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawWireSphere(transform.position, attackRange);
    //}
}

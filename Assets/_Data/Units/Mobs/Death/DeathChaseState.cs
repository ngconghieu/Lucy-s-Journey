using UnityEngine;

public class DeathChaseState : EnemyChaseState
{
    public DeathChaseState(EnemyState owner) : base(owner)
    {
    }

    protected override bool ChangeToCombatState()
    {
        return owner.distanceToPlayer < owner.distanceToAttack || 
            owner.specialAttackTimer > owner.specialAttackDelay ||
            owner.specialAttackTimer1 > owner.specialAttackDelay1;
    }
    protected override void OnMove()
    {
        if (CanMove())
        {
            owner.EnemyCtrl.moving = true;
            owner.EnemyCtrl.Rigidbody.linearVelocityX = owner.EnemyCtrl.transform.localScale.x
                * owner.EnemyCtrl.EnemiesSO.moveSpeed;
        }
        else
        {
            StopMoving();
            timer += Time.deltaTime;
            if (timer > owner.delayChase)
            {
                if (!owner.EnemyCtrl.detectPlayer)
                    Flip();
                timer = 0;
            }
        }
    }

    private void Flip()
    {
        owner.EnemyCtrl.transform.localScale = new Vector2(
            -owner.EnemyCtrl.transform.localScale.x,
            owner.EnemyCtrl.transform.localScale.y);
    }

    private bool CanMove()
    {
        return !owner.EnemyCtrl.CheckWall.IsWall()
            && owner.distanceToPlayer > owner.distanceToAttack;
    }
}
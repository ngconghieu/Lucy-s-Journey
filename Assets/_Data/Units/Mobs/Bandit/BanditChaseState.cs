using UnityEngine;

public class BanditChaseState : EnemyChaseState
{
    public BanditChaseState(EnemyState owner) : base(owner) { }

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
        return owner.EnemyCtrl.CheckGround.IsGrounded()
            && !owner.EnemyCtrl.CheckWall.IsWall()
            && owner.distanceToPlayer > owner.distanceToAttack;
    }
}
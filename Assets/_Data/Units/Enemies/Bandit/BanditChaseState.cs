using System;
using UnityEngine;

public class BanditChaseState : State<BanditState>
{
    float timer = 0;
    float reachedTimer = 0.5f;
    float dirToPlayer;
    public BanditChaseState(BanditState owner) : base(owner) { }

    public override void EnterState()
    {
        Debug.Log("Enter chase state");
    }

    public override void ExecuteState()
    {
        owner.BanditCtrl.moving = owner.BanditCtrl.CheckTerrain.IsGrounded()
            && !owner.BanditCtrl.CheckTerrain.IsWall() && owner.distanceToPlayer > 1;
        Move();
    }

    public override void ExitState()
    {
        //Debug.Log("Enemy chase exited");
        timer = 0;
        owner.BanditCtrl.Rigidbody.linearVelocityX = 0;
        owner.BanditCtrl.moving = false;
    }

    private void Move()
    {
        if (owner.BanditCtrl.moving)
        {
            if (owner.BanditCtrl.detectPlayer)
            {
                dirToPlayer = Mathf.Sign(owner.posPlayer.transform.position.x - owner.transform.position.x);
                owner.transform.localScale = new Vector2(dirToPlayer, owner.transform.localScale.y);
                timer += Time.deltaTime;
                if (timer < reachedTimer) return;
            }
            OnMove();
        }
        else
        {
            owner.BanditCtrl.Rigidbody.linearVelocityX = 0;
            Flip();
            owner.StateMachine.ChangeState(new BanditIdleState(owner));
        }
    }

    private void OnMove()
    {
        timer = 0;
        owner.BanditCtrl.Rigidbody.linearVelocityX = owner.BanditCtrl.transform.localScale.x
            * owner.BanditCtrl.EnemiesSO.moveSpeed;
    }

    private void Flip()
    {
        owner.BanditCtrl.transform.localScale = new Vector2(-owner.BanditCtrl.transform.localScale.x, owner.BanditCtrl.transform.localScale.y);
    }
}
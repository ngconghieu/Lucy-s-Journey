using System;
using UnityEngine;

public class BanditChaseState : State<BanditState>
{
    float timer = 0;
    float dirToPlayer;
    public BanditChaseState(BanditState owner) : base(owner) { }

    public override void EnterState()
    {
        //Debug.Log("Enter chase state");
    }

    public override void ExecuteState()
    {
        if (owner.BanditCtrl.detectPlayer) Detected();
        else
        {
            OnMove();
        }
    }

    private void Detected()
    {
        if (owner.distanceToPlayer < owner.distanceToAttack) owner.StateMachine.ChangeState(new BanditCombatState(owner));
        dirToPlayer = Mathf.Sign(owner.posPlayer.transform.position.x - owner.transform.position.x);
        owner.transform.localScale = new Vector2(dirToPlayer, owner.transform.localScale.y);
        StopMoving();
        timer += Time.deltaTime;
        if (timer > owner.delayChase)
            OnMove();
    }

    public override void ExitState()
    {
        //Debug.Log("Enemy chase exited");
        StopMoving();
        timer = 0;
    }

    private void StopMoving()
    {
        owner.BanditCtrl.moving = false;
        owner.BanditCtrl.Rigidbody.linearVelocityX = 0;
    }

    private void OnMove()
    {
        if (CanMove())
        {
            //Debug.Log("OnMove");
            owner.BanditCtrl.moving = true;
            owner.BanditCtrl.Rigidbody.linearVelocityX = owner.BanditCtrl.transform.localScale.x
                * owner.BanditCtrl.EnemiesSO.moveSpeed;
        }
        else
        {
            StopMoving();
            timer += Time.deltaTime;
            if (timer > owner.delayChase)
            {
                if (!owner.BanditCtrl.detectPlayer)
                    Flip();
                timer = 0;
            }

        }
    }

    private void Flip()
    {
        owner.BanditCtrl.transform.localScale = new Vector2(-owner.BanditCtrl.transform.localScale.x, owner.BanditCtrl.transform.localScale.y);
    }

    private bool CanMove()
    {
        return owner.BanditCtrl.CheckGround.IsGrounded()
                && !owner.BanditCtrl.CheckWall.IsWall() && owner.distanceToPlayer > owner.distanceToAttack;
    }
}
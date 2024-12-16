using System;
using UnityEngine;

public class BanditChaseState : State<BanditState>
{
    public BanditChaseState(BanditState owner) : base(owner) { }
    BanditState banditState;

    public override void EnterState()
    {
        //Debug.Log("Enter chase state");
    }

    public override void ExecuteState()
    {
        owner.BanditCtrl.moving = owner.BanditCtrl.CheckTerrain.IsGrounded() && !owner.BanditCtrl.CheckTerrain.IsWall();
        OnMove();
        if(!owner.BanditCtrl.moving)
        {
            Flip();
            owner.StateMachine.ChangeState(new BanditIdleState(owner));
        }
    }

    public override void ExitState()
    {
        //Debug.Log("Enemy chase exited");
        owner.BanditCtrl.Rigidbody.linearVelocityX = 0;
    }

    private void OnMove()
    {
        owner.BanditCtrl.Rigidbody.linearVelocityX = owner.BanditCtrl.transform.localScale.x
            * owner.BanditCtrl.EnemiesSO.moveSpeed;
    }

    private void Flip()
    {
        owner.BanditCtrl.transform.localScale = new Vector2(-owner.BanditCtrl.transform.localScale.x, owner.BanditCtrl.transform.localScale.y);
    }
}
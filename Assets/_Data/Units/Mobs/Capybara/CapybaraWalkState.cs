using System;
using UnityEngine;

public class CapybaraWalkState : State<CapybaraState>
{
    float timer;
    public CapybaraWalkState(CapybaraState owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        timer = 0;
        owner.CapybaraCtrl.moving = true;
    }

    public override void ExecuteState()
    {
        timer += Time.deltaTime;
        if (timer > owner.walkingTime)
            owner.StateMachine.ChangeState(new CapybaraIdleState(owner));
        //owner.CapybaraCtrl.Rigidbody.linearVelocityX = owner.CapybaraCtrl.EnemiesSO.moveSpeed * owner.transform.localScale.x;
        OnMove();
    }

    private void OnMove()
    {
        if (CanMove())
            owner.CapybaraCtrl.Rigidbody.linearVelocityX = owner.CapybaraCtrl.EnemiesSO.moveSpeed * owner.transform.localScale.x;
        else
        {
            owner.transform.localScale = new Vector3(-owner.transform.localScale.x, owner.transform.localScale.y);
        }
    }

    private bool CanMove()
    {
        return !owner.CapybaraCtrl.CheckWall.IsWall();
    }

    public override void ExitState()
    {
        owner.CapybaraCtrl.moving = false;
        owner.CapybaraCtrl.Rigidbody.linearVelocityX = 0;
    }
}

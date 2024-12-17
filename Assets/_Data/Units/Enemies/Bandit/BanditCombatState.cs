using System;
using UnityEngine;

public class BanditCombatState : State<BanditState>
{
    float timer = 0;
    float reachedTimer = 1;
    public BanditCombatState(BanditState owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        Debug.Log("EnterCombat");
        owner.BanditCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
    }

    public override void ExecuteState()
    {
        timer += Time.deltaTime;
        if (timer >= reachedTimer) owner.StateMachine.ChangeState(new BanditIdleState(owner));
    }

    public override void ExitState()
    {
        timer = 0;
    }

}

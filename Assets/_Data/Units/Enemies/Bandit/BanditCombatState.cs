using UnityEngine;

public class BanditCombatState : State<BanditState>
{
    float timer = 0;
    int comboTime = 0;
    public BanditCombatState(BanditState owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        //Debug.Log("EnterCombat");
    }

    public override void ExecuteState()
    {
        timer += Time.deltaTime;
        if (timer >= owner.delayHit)
        {
            owner.StateMachine.ChangeState(new BanditChaseState(owner));
        }
        if (comboTime < owner.maxCombo) Attack();
    }

    public override void ExitState()
    {
        timer = 0;
    }

    private void Attack()
    {
        comboTime++;
        owner.BanditCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
    }
}

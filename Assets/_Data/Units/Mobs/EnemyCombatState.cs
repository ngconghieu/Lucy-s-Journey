using UnityEngine;

public class EnemyCombatState : State<EnemyState>
{
    protected float timer = 0;
    protected int comboTime = 0;

    public EnemyCombatState(EnemyState owner) : base(owner) { }

    public override void EnterState() { }

    public override void ExecuteState()
    {
        timer += Time.deltaTime;
        //if (timer >= owner.delayHit)
        if (comboTime >= owner.maxCombo && timer >= owner.delayHit)
        {
            owner.StateMachine.ChangeState(owner.GetChaseState());
        }
        if (comboTime < owner.maxCombo)
            Attack();
    }

    public override void ExitState()
    {
        timer = 0;
    }

    protected virtual void Attack()
    {
        //For Override
        comboTime++;
        owner.AnimTriggerAttack();
    }
}
using UnityEngine;

public abstract class EnemyCombatState<T> : State<T> where T : EnemyState
{
    protected float timer = 0;
    protected int comboTime = 0;

    public EnemyCombatState(T owner) : base(owner) { }

    public override void EnterState() { }

    public override void ExecuteState()
    {
        timer += Time.deltaTime;
        if (timer >= owner.delayHit)
        {
            owner.StateMachine.ChangeState(owner.GetStartState());
        }
        if (comboTime < owner.maxCombo)
            Attack();
    }

    public override void ExitState()
    {
        timer = 0;
    }

    protected abstract void Attack();
}
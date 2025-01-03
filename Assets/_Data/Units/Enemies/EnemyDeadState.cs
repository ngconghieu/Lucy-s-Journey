using UnityEngine;

public abstract class EnemyDeadState<T> : State<T> where T : EnemyState
{
    protected float timer;
    protected int dropItem = 0;

    public EnemyDeadState(T owner) : base(owner) { }

    public override void EnterState()
    {
        timer = 0;
        owner.EnemyCtrl.dead = true;
        OnEnterState();
    }

    public override void ExecuteState()
    {
        if (dropItem < owner.dropItemCnt)
        {
            DropManager.Instance.Drop(owner.EnemyCtrl.EnemiesSO.dropList);
            dropItem++;
        }

        timer += Time.deltaTime;
        if (timer > owner.cdToDespawn)
            owner.gameObject.SetActive(false);
    }

    public override void ExitState() { }

    protected abstract void OnEnterState();
}
using UnityEngine;

public class EnemyDeadState : State<EnemyState>
{
    protected float timer;
    protected int dropItem = 0;

    public EnemyDeadState(EnemyState owner) : base(owner) { }

    public override void EnterState()
    {
        timer = 0;
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

    protected virtual void OnEnterState()
    {
        //For override
        owner.AnimTriggerDead();
    }
}
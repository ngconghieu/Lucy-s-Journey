using UnityEngine;

public class CapybaraDeadState : State<CapybaraState>
{
    float timer = 0;
    int dropItem = 0;
    public CapybaraDeadState(CapybaraState owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        owner.CapybaraCtrl.dead = true;
        owner.AnimTriggerDead();
    }

    public override void ExecuteState()
    {
        if (dropItem < owner.dropItemCnt)
        {
            DropManager.Instance.Drop(owner.CapybaraCtrl.EnemiesSO.dropList,owner.transform.position);
            dropItem++;
        }
        timer += Time.deltaTime;
        if (timer > owner.cdToDespawn)
            owner.gameObject.SetActive(false);
    }

    public override void ExitState()
    {
    }
}

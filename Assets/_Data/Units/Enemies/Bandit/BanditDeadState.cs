using UnityEngine;

public class BanditDeadState : State<BanditState>
{
    float timer;
    int dropItem = 0;
    public BanditDeadState(BanditState owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        timer = 0;
        owner.BanditCtrl.dead = true;
        owner.BanditCtrl.BanditAnim.TriggerDead();
    }

    public override void ExecuteState()
    {
        if (dropItem < owner.dropItemCnt)
        {
            DropManager.Instance.Drop(owner.BanditCtrl.EnemiesSO.dropList);
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

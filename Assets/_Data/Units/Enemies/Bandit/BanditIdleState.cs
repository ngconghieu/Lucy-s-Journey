using System.Collections;
using UnityEngine;

public class BanditIdleState : State<BanditState>
{
    public BanditIdleState(BanditState owner) : base(owner) { }

    public override void EnterState()
    {
        //Debug.Log("Enemy Idle State");
    }

    public override void ExecuteState()
    {
        owner.StartCoroutine(IdleDelay());
    }

    public override void ExitState()
    {
        //Debug.Log("Enemy exited idle");
    }

    IEnumerator IdleDelay()
    {
        //Debug.Log("Enemy idling...");
        yield return new WaitForSeconds(0.5f);
        if(owner.StateMachine.currentState == this)
            owner.StateMachine.ChangeState(new BanditChaseState(owner));
    }
}

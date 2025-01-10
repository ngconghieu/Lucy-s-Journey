using UnityEngine;

public class CapybaraIdleState : State<CapybaraState>
{
    public CapybaraIdleState(CapybaraState owner) : base(owner)
    {
    }

    public override void EnterState()
    {

    }

    public override void ExecuteState()
    {
        if (owner.canMove)
            owner.StateMachine.ChangeState(new CapybaraWalkState(owner));
    }

    public override void ExitState()
    {
        
    }
}

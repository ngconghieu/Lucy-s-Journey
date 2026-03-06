public class PlayerIdleState : BaseState
{

    public override void Enter()
    {
        IsCompleted = true; // Set to true to allow transition to other states immediately
        //Debug.Log("PlayerIdleState Enter");
    }

    public override void Exit()
    {
        //Debug.Log("PlayerIdleState Exit");
    }

    public override void FixedDo()
    {
    }

    public override void Do()
    {
    }

}
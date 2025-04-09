using System.Collections;
using UnityEngine;

public class PlayerIdleState : BaseState<PlayerState, Player>
{
    public PlayerIdleState(Player owner) : base(owner)
    {
    }

    public override void Enter()
    {
        Debug.Log("PlayerIdleState Enter");
    }

    public override void Exit()
    {
        Debug.Log("PlayerIdleState Exit");
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
        if (InputManager.Instance.RunHorizontal != 0)
        {
            Owner.StateMachine.ChangeState(PlayerState.Run);
        }
    }

}
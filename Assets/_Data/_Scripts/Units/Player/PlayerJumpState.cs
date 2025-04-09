using UnityEngine;

public class PlayerJumpState : BaseState<PlayerState, Player>
{
    public PlayerJumpState(Player owner) : base(owner)
    {
    }

    public override void Enter()
    {
        Debug.Log("PlayerJumpState Enter");
    }

    public override void Exit()
    {
        Debug.Log("PlayerJumpState Exit");
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
    }
}
using UnityEngine;

public class MoveState : State
{
    Rigidbody2D rb;
    float speed;

    public MoveState(GameObject state, Rigidbody2D rb, float speed) : base(state)
    {
        this.rb = rb;
        this.speed = speed;
    }

    public override void Enter()
    {
        Debug.Log("Entering Move State");
    }

    public override void Update()
    {
        rb.linearVelocityX = speed * state.transform.localScale.x;
    }

    public override void Exit()
    {
        rb.linearVelocity = Vector2.zero;
    }
}

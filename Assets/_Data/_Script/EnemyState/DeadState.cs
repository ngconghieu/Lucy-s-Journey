using UnityEngine;

public class DeadState : State
{
    private Animator anim;
    public DeadState(GameObject state, Animator anim) : base(state)
    {
        this.anim = anim;
    }

    public override void Enter()
    {
        Debug.Log("Entering Dead State");
        anim.SetTrigger(AnimStrings.isDead);
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}

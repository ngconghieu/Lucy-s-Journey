using UnityEngine;

public class BanditCtrl : BanditBase
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.ChangeState(new MoveState(gameObject, rb, moveSpeed));
    }

    public void OnDead()
    {
        stateMachine.ChangeState(new DeadState(gameObject, anim));
    }
}

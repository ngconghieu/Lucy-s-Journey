using System;
using UnityEngine;

public class PlayerCtrl : GameMonoBehaviour
{
    [Header("Get Components")]
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected Animator animator;
    [SerializeField] protected PlayerAnim playerAnim;

    [Header("State")]
    public bool Dashing;
    public float Moving;
    public bool Jumping;
    public bool DoubleJump;
    public bool IsGrounded;
    public bool IsWall;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => animator;
    public PlayerAnim PlayerAnim => playerAnim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
        this.LoadAnimator();
        this.LoadPlayerAnim();
    }

    private void LoadPlayerAnim()
    {
        if (this.playerAnim != null) return;
        playerAnim = transform.Find("Anim").GetComponent<PlayerAnim>();
        Debug.LogWarning(transform.name + ": LoadPlayerAnim", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        animator = transform.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody2D != null) return;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigibody", gameObject);
    }
}
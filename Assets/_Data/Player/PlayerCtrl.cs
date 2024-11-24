using System;
using UnityEngine;

public class PlayerCtrl : GameMonoBehaviour
{
    [Header("Get Components")]
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected Animator animator;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => animator;
    [Header("State of character")]
    public bool jumping = false;
    public bool doubleJump = false;
    public bool dashing = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
        this.LoadAnimator();
    }
    protected void Update()
    {
        dashing = Input.GetButtonDown("Horizontal");
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        animator = transform.Find("Model").GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody2D != null) return;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigibody", gameObject);
    }

}

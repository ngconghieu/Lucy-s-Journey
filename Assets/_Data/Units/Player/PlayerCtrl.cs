using System;
using UnityEngine;

public class PlayerCtrl : GameMonoBehaviour
{
    [Header("Get Components")]
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected Animator animator;
    [SerializeField] protected CheckGround checkGround;
    [SerializeField] protected CheckWall checkWall;
    [SerializeField] protected PlayerAnim playerAnim;
    [SerializeField] protected PlayerSO playerSO;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => animator;
    public CheckGround CheckGround => checkGround;
    public CheckWall CheckWall => checkWall;
    public PlayerAnim PlayerAnim => playerAnim;
    public PlayerSO PlayerSO => playerSO;

    [Header("State")]
    public bool Dashing;
    public float Moving;
    public bool Jumping;
    public bool DoubleJump;
    public bool IsGrounded;
    public bool IsWall;

    #region Load Components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
        this.LoadAnimator();
        this.LoadCheckGround();
        this.LoadCheckWall();
        this.LoadPlayerAnim();
        this.LoadPlayerSO();
    }

    private void LoadCheckWall()
    {
        if (this.checkWall != null) return;
        checkWall = transform.GetComponentInChildren<CheckWall>();
        Debug.LogWarning("LoadCheckWall", gameObject);
    }

    private void LoadCheckGround()
    {
        if (this.checkGround != null) return;
        checkGround = GetComponentInChildren<CheckGround>();
        Debug.LogWarning(transform.name + ": LoadCheckGround", gameObject);
    }

    private void LoadPlayerSO()
    {
        if (this.playerSO != null) return;
        string path = "Player/" + transform.parent.name;
        playerSO = Resources.Load<PlayerSO>(path);
        Debug.LogWarning(transform.name + ": LoadPlayerSO", gameObject);
    }

    private void LoadPlayerAnim()
    {
        if (this.playerAnim != null) return;
        playerAnim = GetComponentInChildren<PlayerAnim>();
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
    #endregion
}
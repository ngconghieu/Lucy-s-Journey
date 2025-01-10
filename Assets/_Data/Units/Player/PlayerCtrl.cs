using System;
using UnityEngine;

public class PlayerCtrl : GameMonoBehaviour
{
    [Header("Get Components")]
    [SerializeField] protected CapsuleCollider2D capsuleCollider;
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected Animator animator;
    [SerializeField] protected CheckGround checkGround;
    [SerializeField] protected CheckWall checkWall;
    [SerializeField] protected PlayerAnim playerAnim;
    [SerializeField] protected DmgReceiver dmgReceiver;
    [SerializeField] protected PlayerSO playerSO;
    [SerializeField] protected Heartbar heartbar;
    public CapsuleCollider2D CapsuleCollider => capsuleCollider;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => animator;
    public CheckGround CheckGround => checkGround;
    public CheckWall CheckWall => checkWall;
    public PlayerAnim PlayerAnim => playerAnim;
    public DmgReceiver DmgReceiver => dmgReceiver;
    public PlayerSO PlayerSO => playerSO;

    public Heartbar Heartbar => heartbar;

    [Header("State")]
    public bool Dashing;
    public float Moving;
    public bool Jumping;
    public bool DoubleJump;
    public bool IsGrounded;
    public bool IsWall;
    public bool notAttack = true;// check on animation
    public bool slideWall;
    public bool wallJump;
    public bool dead;

    #region Load Components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
        this.LoadAnimator();
        this.LoadCheckGround();
        this.LoadCheckWall();
        this.LoadPlayerAnim();
        this.LoadDmgReceiver();
        this.LoadPlayerSO();
        this.LoadHeartBar();
    }

    private void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        capsuleCollider = transform.GetComponent<CapsuleCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    private void LoadDmgReceiver()
    {
        if (this.dmgReceiver != null) return;
        dmgReceiver = GetComponentInChildren<DmgReceiver>();
        Debug.LogWarning(transform.name + ": LoadDmgReceiver", gameObject);
    }

    private void LoadHeartBar()
    {
        if (this.heartbar != null) return;
        heartbar = GetComponentInChildren<Heartbar>();
        Debug.LogWarning(transform.name + ": LoadHeartBar", gameObject);
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
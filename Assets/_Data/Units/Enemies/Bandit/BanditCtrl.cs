using UnityEngine;

public class BanditCtrl : GameMonoBehaviour
{
    [Header("Load components")]
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CheckGround checkGround;
    [SerializeField] CheckWall checkWall;
    [SerializeField] DetectPlayer _detectPlayer;
    [SerializeField] BanditAnim banditAnim;
    [SerializeField] DmgReceiver dmgReceiver;
    [SerializeField] DmgSender dmgSender;
    [SerializeField] EnemiesSO enemiesSO;
    public Animator Animator => anim;
    public Rigidbody2D Rigidbody => rb;
    public CheckGround CheckGround => checkGround;
    public CheckWall CheckWall => checkWall;
    public DetectPlayer DetectPlayer => _detectPlayer;
    public BanditAnim BanditAnim => banditAnim;
    public DmgReceiver DmgReceiver => dmgReceiver;
    public DmgSender DmgSender => dmgSender;
    public EnemiesSO EnemiesSO => enemiesSO;

    [Header("States")]
    public bool moving;
    public bool detectPlayer;
    public bool canAttack;
    public bool dead;
    public bool hit;
    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnim();
        LoadRigibody();
        LoadCheckGround();
        LoadCheckWall();
        LoadDetectPlayer();
        LoadBanditAnim();
        LoadDmgReceiver();
        LoadDmgSender();
        LoadEnemiesSO();
    }

    private void LoadDmgSender()
    {
        if (this.dmgSender != null) return;
        dmgSender = transform.GetComponentInChildren<DmgSender>();
        Debug.LogWarning("LoadDmgSender", gameObject);
    }

    private void LoadDmgReceiver()
    {
        if (this.dmgReceiver != null) return;
        dmgReceiver = transform.GetComponentInChildren<DmgReceiver>();
        Debug.LogWarning("LoadDmgReceiver", gameObject);
    }

    private void LoadCheckWall()
    {
        if (this.checkWall != null) return;
        checkWall = transform.GetComponentInChildren<CheckWall>();
        Debug.LogWarning("LoadCheckWall", gameObject);
    }

    private void LoadDetectPlayer()
    {
        if (this._detectPlayer != null) return;
        _detectPlayer = transform.GetComponentInChildren<DetectPlayer>();
        Debug.LogWarning("LoadDetectPlayer", gameObject);
    }

    private void LoadBanditAnim()
    {
        if (this.banditAnim != null) return;
        banditAnim = transform.GetComponentInChildren<BanditAnim>();
        Debug.LogWarning("LoadBanditAnim", gameObject);
    }

    private void LoadCheckGround()
    {
        if (this.checkGround != null) return;
        checkGround = transform.GetComponentInChildren<CheckGround>();
        Debug.LogWarning("LoadCheckGround", gameObject);
    }

    private void LoadRigibody()
    {
        if (this.rb != null) return;
        rb = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigibody", gameObject);
    }

    private void LoadAnim()
    {
        if (this.anim != null) return;
        anim = transform.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnim", gameObject);
    }
    private void LoadEnemiesSO()
    {
        if (this.enemiesSO != null) return;
        string resPath = "Enemies/" + transform.name;
        this.enemiesSO = Resources.Load<EnemiesSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadEnemiesSO", gameObject);
    }
    #endregion

}
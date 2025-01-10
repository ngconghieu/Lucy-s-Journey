using System;
using UnityEngine;

public class CapybaraCtrl : GameMonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected CapybaraAnim capybaraAnim;
    [SerializeField] protected CheckWall checkWall;
    [SerializeField] protected DmgReceiver dmgReceiver;
    [SerializeField] protected EnemiesSO enemiesSO;

    public Animator Animator => anim;
    public Rigidbody2D Rigidbody => rb;
    public CapybaraAnim CapybaraAnim => capybaraAnim;
    public CheckWall CheckWall => checkWall;
    public DmgReceiver DmgReceiver => dmgReceiver;
    public EnemiesSO EnemiesSO => enemiesSO;

    [Header("States")]
    public bool moving;
    public bool dead;

    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnim();
        LoadRigibody();
        LoadCapybaraAnim();
        LoadCheckWall();
        LoadDmgReceiver();
        LoadEnemiesSO();
    }

    private void LoadCapybaraAnim()
    {
        if (this.capybaraAnim != null) return;
        capybaraAnim = transform.GetComponentInChildren<CapybaraAnim>();
        Debug.LogWarning("LoadCapybaraAnim", gameObject);
    }

    private void LoadEnemiesSO()
    {
        if (enemiesSO != null) return;
        string resPath = "Enemies/" + transform.name;
        enemiesSO = Resources.Load<EnemiesSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadEnemiesSO", gameObject);
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
    #endregion
}

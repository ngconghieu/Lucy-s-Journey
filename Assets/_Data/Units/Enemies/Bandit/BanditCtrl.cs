using System;
using UnityEngine;

public class BanditCtrl : GameMonoBehaviour
{
    [Header("Load components")]
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CheckTerrain checkTerrain;
    [SerializeField] BanditAnim banditAnim;
    [SerializeField] EnemiesSO enemiesSO;
    public Animator Animator => anim;
    public Rigidbody2D Rigidbody => rb;
    public CheckTerrain CheckTerrain => checkTerrain;
    public BanditAnim BanditAnim => banditAnim;
    public EnemiesSO EnemiesSO => enemiesSO;

    [Header("States")]
    public bool moving;
    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnim();
        this.LoadRigibody();
        this.LoadCheckTerrain();
        this.LoadBanditAnim();
        this.LoadEnemiesSO();
    }

    private void LoadBanditAnim()
    {
        if(this.banditAnim != null) return;
        banditAnim = transform.GetComponentInChildren<BanditAnim>();
        Debug.LogWarning("LoadBanditAnim", gameObject);
    }

    private void LoadCheckTerrain()
    {
        if (this.checkTerrain != null) return;
        checkTerrain = transform.GetComponentInChildren<CheckTerrain>();
        Debug.LogWarning("LoadCheckTerrain", gameObject);
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
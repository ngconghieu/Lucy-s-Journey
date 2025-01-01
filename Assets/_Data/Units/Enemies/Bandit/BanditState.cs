using System;
using UnityEngine;

public class BanditState : GameMonoBehaviour
{
    public StateMachine<BanditState> StateMachine { get; private set; }
    [SerializeField] protected BanditCtrl banditCtrl;
    public BanditCtrl BanditCtrl => banditCtrl;
    
    [Header("Chase state")]
    public GameObject posPlayer;
    public float detectPlayerRange = 10f;
    public float distanceToPlayer;
    public float delayChase = 0.5f;
    public float distanceToAttack = 1f;
    [Header("Combat state")]
    public float delayHit = 1f;
    public int maxCombo = 1;
    public int dmg = 1;
    [Header("Received dmg state")]
    public float delayWhenReceivedDmg = 0.5f;
    [Header("Dead state")]
    public float cdToDespawn = 3f;
    public int dropItemCnt = 1;

    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBanditCtrl();
    }

    private void LoadBanditCtrl()
    {
        if (banditCtrl != null) return;
        banditCtrl = GetComponent<BanditCtrl>();
        Debug.LogWarning("LoadBanditCtrl", gameObject);
    }
    #endregion

    protected override void Start()
    {
        base.Start();
        posPlayer = GameObject.FindGameObjectWithTag("Player");
        StateMachine = new StateMachine<BanditState>(this);

        //set start state
        StateMachine.ChangeState(new BanditChaseState(this));

        //set maxHp
        banditCtrl.DmgReceiver.SetMaxHp(banditCtrl.EnemiesSO.hpMax);
        banditCtrl.DmgReceiver.Reborn();
        
        //set dmg
        dmg = banditCtrl.EnemiesSO.dmg;
        banditCtrl.DmgSender.SetDmg(dmg);

        //subscribe event
        banditCtrl.DmgReceiver.OnHurt += HandleHurt;
        banditCtrl.DmgReceiver.OnDead += HandleDead;
    }

    protected virtual void Update()
    {
        StateMachine.ExecuteState();
        if (banditCtrl.dead || banditCtrl.hit) return;
        DetectPlayerInRange();

    }

    protected override void OnDisable()
    {
        banditCtrl.DmgReceiver.OnHurt -= HandleHurt;
        banditCtrl.DmgReceiver.OnDead -= HandleDead;
    }

    private void HandleHurt(LayerMask layer)
    {
        //Debug.Log("Hited");
        if (layer == LayerMask.NameToLayer("Player"))
            StateMachine.ChangeState(new BanditReceiveDmgState(this));
    }

    private void HandleDead()
    {
        Debug.Log("Dead");
        StateMachine.ChangeState(new BanditDeadState(this));
    }

    private void DetectPlayerInRange()
    {
        banditCtrl.detectPlayer = banditCtrl.DetectPlayer.DetectPlayerForGround(detectPlayerRange);
        distanceToPlayer = Vector2.Distance(posPlayer.transform.position, transform.position);
        if (banditCtrl.detectPlayer)
        {
            if (distanceToPlayer < 1 && StateMachine.currentState is not BanditCombatState)
                StateMachine.ChangeState(new BanditCombatState(this));
        }
    }
}
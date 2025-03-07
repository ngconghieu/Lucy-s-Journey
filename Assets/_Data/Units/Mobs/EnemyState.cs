﻿using System;
using UnityEngine;

public abstract class EnemyState : GameMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    public StateMachine<EnemyState> StateMachine { get; private set; }

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
    public float specialAttackTimer = 0;
    public float specialAttackDelay = 1;
    public bool canPerformSpecialAttack; //Check on animation
    public float specialAttackTimer1 = 0;
    public float specialAttackDelay1 = 1;
    public bool canPerformSpecialAttack1; //Check on animation

    [Header("Received dmg state")]
    public float delayWhenReceivedDmg = 0.5f;
    [Header("Dead state")]
    public float cdToDespawn = 3f;
    public int dropItemCnt = 1;

    #region Load Components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = GetComponent<EnemyCtrl>();
        Debug.LogWarning($"Load{GetType().Name}Ctrl", gameObject);
    }
    #endregion

    protected override void Start()
    {
        base.Start();
        posPlayer = GameObject.FindGameObjectWithTag("Player");
        StateMachine = new StateMachine<EnemyState>(this);

        InitializeEnemy();
        SubscribeEvents();

        //Start state
        StateMachine.ChangeState(GetChaseState());
    }

    protected virtual void InitializeEnemy()
    {
        //set maxHp
        enemyCtrl.DmgReceiver.SetMaxHp(enemyCtrl.EnemiesSO.hpMax);
        enemyCtrl.DmgReceiver.Reborn();

        //set dmg
        dmg = enemyCtrl.EnemiesSO.dmg;
        enemyCtrl.DmgSender.SetDmg(dmg);
    }

    protected virtual void SubscribeEvents()
    {
        enemyCtrl.DmgReceiver.OnHurt += HandleHurt;
        enemyCtrl.DmgReceiver.OnDead += HandleDead;
    }

    protected virtual void UnsubscribeEvents()
    {
        enemyCtrl.DmgReceiver.OnHurt -= HandleHurt;
        enemyCtrl.DmgReceiver.OnDead -= HandleDead;
    }

    protected virtual void Update()
    {
        distanceToPlayer = Vector2.Distance(posPlayer.transform.position, transform.position);
        UpdateTimer();
        StateMachine.ExecuteState();
        if (!enemyCtrl.dead && !enemyCtrl.hit)
        {
            DetectPlayerInRange();
        }
    }

    private void UpdateTimer()
    {
        specialAttackTimer += Time.deltaTime;
        specialAttackTimer1 += Time.deltaTime;

    }

    protected override void OnDisable()
    {
        UnsubscribeEvents();
    }

    protected virtual void HandleHurt(LayerMask layer)
    {
        if (layer == LayerMask.NameToLayer("Player"))
        {
            enemyCtrl.hit = true;
            if (StateMachine.currentState != GetHitState())
                StateMachine.ChangeState(GetHitState());
        }
    }

    protected virtual void HandleDead()
    {
        enemyCtrl.dead = true;
        if (StateMachine.currentState is not EnemyDeadState)
            StateMachine.ChangeState(GetDeadState());
    }

    protected virtual void DetectPlayerInRange()
    {
        enemyCtrl.detectPlayer = enemyCtrl.DetectPlayer.DetectPlayerForGround(detectPlayerRange);

        //if (enemyCtrl.detectPlayer && distanceToPlayer < distanceToAttack
        //    && StateMachine.currentState != GetCombatState())
        //{
        //    StateMachine.ChangeState(GetCombatState());
        //}
    }

    // Abstract methods for states
    public abstract State<EnemyState> GetChaseState();
    public abstract State<EnemyState> GetHitState();
    public abstract State<EnemyState> GetDeadState();
    public abstract State<EnemyState> GetCombatState();
    public virtual State<EnemyState> GetIdleState()
    {
        return null;
        //For override
    }
    public abstract void AnimTriggerHit();
    public abstract void AnimTriggerDead();
    public abstract void AnimTriggerAttack();
    public virtual void AnimTriggerSpecialAttack()
    {
        //For override
    }
    public virtual void AnimTriggerSpecialAttack1()
    {
        //For override
    }
    public virtual void AnimTriggerSpecialAttack2()
    {
        //For override
    }


}
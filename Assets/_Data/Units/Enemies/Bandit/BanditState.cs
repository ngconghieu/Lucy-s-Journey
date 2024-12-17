using System;
using UnityEngine;

public class BanditState : GameMonoBehaviour
{
    public StateMachine<BanditState> StateMachine { get; private set; }
    [SerializeField] protected BanditCtrl banditCtrl;
    public BanditCtrl BanditCtrl => banditCtrl;
    public GameObject posPlayer;
    public float detectPlayerRange = 10f;
    public float distanceToPlayer;
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
        StateMachine.ChangeState(new BanditIdleState(this));
    }

    protected virtual void Update()
    {
        StateMachine.ExecuteState();
        DetectPlayerInRange();

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
using System;
using UnityEngine;

public class BanditState : GameMonoBehaviour
{
    public StateMachine<BanditState> StateMachine { get; private set; }
    [SerializeField] protected BanditCtrl banditCtrl;
    public BanditCtrl BanditCtrl => banditCtrl;

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

    protected override void Start()
    {
        base.Start();
        StateMachine = new StateMachine<BanditState>(this);

        //set start state
        StateMachine.ChangeState(StartState());
    }

    protected virtual void Update()
    {
        StateMachine.ExecuteState();
    }

    public virtual State<BanditState> StartState()
    {
        return new BanditIdleState(this);
    }
}
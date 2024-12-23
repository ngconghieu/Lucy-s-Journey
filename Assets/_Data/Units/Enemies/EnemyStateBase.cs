using UnityEngine;

public abstract class EnemyStateBase
{
    public GameObject posPlayer;
    public float DistanceToPlayer { get; protected set; }
    public float DetectPlayerRange { get; protected set; }
    public EnemyCtrlBase EnemyCtrl { get; protected set; }
    public StateMachine<EnemyStateBase> StateMachine { get; protected set; }

    protected EnemyStateBase(EnemyCtrlBase ctrl)
    {
        EnemyCtrl = ctrl;
        posPlayer = GameObject.FindGameObjectWithTag("Player");
        StateMachine = new StateMachine<EnemyStateBase>(this);
    }

    public virtual void ExecuteState()
    {
        DistanceToPlayer = Vector3.Distance(EnemyCtrl.transform.position, posPlayer.transform.position);
        StateMachine.ExecuteState();
    }
}
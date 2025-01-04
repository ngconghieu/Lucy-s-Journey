using UnityEngine;

public class EnemyChaseState : State<EnemyState>
{
    protected float timer = 0;
    protected float dirToPlayer;

    public EnemyChaseState(EnemyState owner) : base(owner) { }

    public override void ExecuteState()
    {
        if (owner.EnemyCtrl.detectPlayer)
            Detected();
        else
            OnMove();
    }

    protected virtual void Detected()
    {
        if (owner.distanceToPlayer < owner.distanceToAttack)
            owner.StateMachine.ChangeState(owner.GetCombatState());

        dirToPlayer = Mathf.Sign(owner.posPlayer.transform.position.x - owner.transform.position.x);
        owner.transform.localScale = new Vector2(dirToPlayer, owner.transform.localScale.y);
        StopMoving();
        timer += Time.deltaTime;
        if (timer > owner.delayChase)
            OnMove();
    }

    protected virtual void StopMoving()
    {
        owner.EnemyCtrl.moving = false;
        owner.EnemyCtrl.Rigidbody.linearVelocityX = 0;
    }

    protected virtual void OnMove()
    {
        //For Override
    }

    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        
    }
}
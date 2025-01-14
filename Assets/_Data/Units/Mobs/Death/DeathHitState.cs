public class DeathHitState : EnemyHitState
{
    public DeathHitState(EnemyState owner) : base(owner)
    {
    }
    protected override void OnEnterState()
    {
        base.OnEnterState();
        timer = 10;
    }
}

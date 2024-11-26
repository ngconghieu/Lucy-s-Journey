using UnityEngine;

public class DespawnFX : DespawnByTime
{
    public override void DespawnObj()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
    protected override void Reset()
    {
        base.Reset();
        delay = 2f;
    }
}

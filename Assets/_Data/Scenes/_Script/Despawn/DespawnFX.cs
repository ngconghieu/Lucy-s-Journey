using UnityEngine;

public class DespawnFX : DespawnByTime
{
    public override void DespawnObj()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}

public class DespawnFX : DespawnByTime
{
    public override void DespawnObj()
    {
        PrefabSpawner.Instance.Despawn(transform.parent);
    }
}
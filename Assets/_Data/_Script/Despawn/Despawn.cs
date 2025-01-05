public abstract class Despawn : GameMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

    protected void Despawning()
    {
        if (!CanDespawn()) return;
        DespawnObj();
    }

    public virtual void DespawnObj()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
}
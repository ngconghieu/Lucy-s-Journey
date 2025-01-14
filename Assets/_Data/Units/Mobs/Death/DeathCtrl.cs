using UnityEngine;

public class DeathCtrl : EnemyCtrl
{
    [Header("Load components")]
    [SerializeField] DeathAnim deathAnim;
    public DeathAnim DeathAnim => deathAnim;

    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDeathAnim();
    }

    private void LoadDeathAnim()
    {
        if (this.deathAnim != null) return;
        deathAnim = transform.GetComponentInChildren<DeathAnim>();
        Debug.LogWarning("LoadDeathAnim", gameObject);
    }
    #endregion
}

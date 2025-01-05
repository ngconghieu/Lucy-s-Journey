using UnityEngine;

public class BanditCtrl : EnemyCtrl
{
    [Header("Load components")]
    [SerializeField] BanditAnim banditAnim;
    public BanditAnim BanditAnim => banditAnim;
    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBanditAnim();
    }

    private void LoadBanditAnim()
    {
        if (this.banditAnim != null) return;
        banditAnim = transform.GetComponentInChildren<BanditAnim>();
        Debug.LogWarning("LoadBanditAnim", gameObject);
    }
    #endregion
}
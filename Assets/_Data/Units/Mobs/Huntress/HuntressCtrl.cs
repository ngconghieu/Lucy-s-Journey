using UnityEngine;

public class HuntressCtrl : EnemyCtrl
{
    [Header("Load components")]
    [SerializeField] HuntressAnim huntressAnim;
    public HuntressAnim HuntressAnim => huntressAnim;

    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHuntressAnim();
    }

    private void LoadHuntressAnim()
    {
        if (this.huntressAnim != null) return;
        huntressAnim = transform.GetComponentInChildren<HuntressAnim>();
        Debug.LogWarning("LoadHuntressAnim", gameObject);
    }
    #endregion
}

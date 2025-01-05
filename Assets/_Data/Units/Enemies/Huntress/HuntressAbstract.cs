using UnityEngine;

public abstract class HuntressAbstract : GameMonoBehaviour
{
    [SerializeField] HuntressCtrl huntressCtrl;
    public HuntressCtrl HuntressCtrl => huntressCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHuntressCtrl();
    }

    private void LoadHuntressCtrl()
    {
        if (huntressCtrl != null) return;
        huntressCtrl = GetComponentInParent<HuntressCtrl>();
        Debug.LogWarning("LoadHuntressCtrl", gameObject);
    }
}

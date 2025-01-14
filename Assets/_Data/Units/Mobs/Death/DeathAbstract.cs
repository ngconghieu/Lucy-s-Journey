using UnityEngine;

public class DeathAbstract : GameMonoBehaviour
{
    [SerializeField] DeathCtrl deathCtrl;
    public DeathCtrl DeathCtrl => deathCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDeathCtrl();
    }

    private void LoadDeathCtrl()
    {
        if (deathCtrl != null) return;
        deathCtrl = GetComponentInParent<DeathCtrl>();
        Debug.LogWarning("LoadDeathCtrl", gameObject);
    }
}

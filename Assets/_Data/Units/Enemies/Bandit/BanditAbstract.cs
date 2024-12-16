using System;
using UnityEngine;

public abstract class BanditAbstract : GameMonoBehaviour
{
    [SerializeField] BanditCtrl banditCtrl;
    public BanditCtrl BanditCtrl => banditCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBanditCtrl();

    }

    private void LoadBanditCtrl()
    {
        if (banditCtrl != null) return;
        banditCtrl = GetComponentInParent<BanditCtrl>();
        Debug.LogWarning("LoadBanditCtrl", gameObject);
    }
}

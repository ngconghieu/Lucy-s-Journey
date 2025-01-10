using System;
using UnityEngine;

public class CapybaraAbstract : GameMonoBehaviour
{
    [SerializeField] private CapybaraCtrl capybaraCtrl;
    public CapybaraCtrl CapybaraCtrl => capybaraCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCapybaraCtrl();
    }

    private void LoadCapybaraCtrl()
    {
        if (capybaraCtrl != null) return;
        capybaraCtrl = GetComponentInParent<CapybaraCtrl>();
        Debug.LogWarning("LoadCapybaraCtrl", gameObject);
    }
}

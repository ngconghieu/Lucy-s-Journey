using System;
using UnityEngine;

public abstract class DmgSender : GameMonoBehaviour
{
    [SerializeField] LayerMask objLayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadObjLayers();
    }

    private void LoadObjLayers()
    {
        objLayer = LayerMask.GetMask("Enemy");

    }
    protected virtual void Update()
    {
        this.Attack();
    }

    protected virtual void Attack()
    {
        
    }
}

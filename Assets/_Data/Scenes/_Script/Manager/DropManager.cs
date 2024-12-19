using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : GameMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("DropManager already exist");
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropItem> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }
}

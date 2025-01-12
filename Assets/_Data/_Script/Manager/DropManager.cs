using System.Collections.Generic;
using UnityEngine;

public class DropManager : GameMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("DropManager already exists");
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropItem> dropList, Vector3 enemyPosition)
    {
        foreach (var item in dropList)
        {

            Debug.Log(item.itemSO.itemName);
            Debug.Log(Instantiate(item.itemSO.prefab, enemyPosition + new Vector3(-2,0,0), Quaternion.identity));
        } 
    }
}
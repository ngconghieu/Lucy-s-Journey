using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GameMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    #region Load components
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    private void LoadHolder()
    {
        if (holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    private void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj) this.prefabs.Add(prefab);
        this.HidePrefabs();
        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }

    private void HidePrefabs()
    {
        foreach (Transform prefab in prefabs) prefab.gameObject.SetActive(false);
    }
    #endregion

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, spawnRot);
        newPrefab.gameObject.SetActive(true);
        newPrefab.parent = this.holder;
        return newPrefab;
    }

    private Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in poolObjs)
        {
            if (poolObj == null) continue;
            if(poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    private Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
            if (prefab.name == prefabName) return prefab;
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}

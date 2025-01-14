using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : GameMonoBehaviour
{
    protected static SpawnPoints instance;
    public static SpawnPoints Instance => instance;
    [SerializeField] protected List<Transform> points;
    public List<Transform> Points => points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        instance = this;
        LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (points.Count > 0) return;
        foreach (Transform point in transform)
            points.Add(point);
        Debug.LogWarning("LoadPoints", gameObject);
    }
}

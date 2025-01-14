using System;
using UnityEngine;

public class DeathCtrl : EnemyCtrl
{
    [Header("Load components")]
    [SerializeField] DeathAnim deathAnim;
    public DeathAnim DeathAnim => deathAnim;
    [SerializeField] SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDeathAnim();
        //LoadSpawnPoints();
    }

    private void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = Transform.FindAnyObjectByType<SpawnPoints>();
        Debug.LogWarning("LoadSpawnPoints", gameObject);
    }

    private void LoadDeathAnim()
    {
        if (this.deathAnim != null) return;
        deathAnim = transform.GetComponentInChildren<DeathAnim>();
        Debug.LogWarning("LoadDeathAnim", gameObject);
    }
    #endregion
}

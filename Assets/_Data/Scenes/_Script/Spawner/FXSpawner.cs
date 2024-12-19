using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public static string DashSmoke = "Player_Dash_Smoke";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("FXSpawner already exist");
        FXSpawner.instance = this;
    }
}

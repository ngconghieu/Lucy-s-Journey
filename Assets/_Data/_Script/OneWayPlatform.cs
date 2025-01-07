using System;
using UnityEngine;

public class OneWayPlatform : GameMonoBehaviour
{
    [SerializeField] protected PlatformEffector2D platformEffector;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlatformEffector();
    }

    private void LoadPlatformEffector()
    {
        if (platformEffector != null) return;
        platformEffector = GetComponent<PlatformEffector2D>();
        Debug.LogWarning("LoadPlatformEffector", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 180;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
    }
}

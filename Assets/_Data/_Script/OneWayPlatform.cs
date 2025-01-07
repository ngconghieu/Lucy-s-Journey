using System;
using System.Collections;
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
    private void Update()
    {
        if (InputManager.Instance.Jump() && InputManager.Instance.JumpDown() == -1) Debug.Log("hehe");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (InputManager.Instance.Jump() && InputManager.Instance.JumpDown() == -1)
            StartCoroutine(OnJumpDown());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
    }

    IEnumerator OnJumpDown()
    {
        platformEffector.rotationalOffset = 180;
        yield return new WaitForSeconds(1);
        platformEffector.rotationalOffset = 0;
    }
}

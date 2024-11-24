using System;
using UnityEngine;

public class FollowTarget : GameMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speedCam = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadTarget();
    }

    private void LoadTarget()
    {
        if (target != null) return;
        this.target = transform.GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }

    protected void FixedUpdate()
    {
        Following();
    }

    private void Following()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speedCam);
    }
}

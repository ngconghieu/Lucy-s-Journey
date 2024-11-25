using System;
using UnityEngine;

public class FollowTarget : GameMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speedCam = 10f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    private void LoadTarget()
    {
        if (target != null) return;
        this.target = GameObject.Find("Player").transform;
        foreach(Transform tf in target)
        {
            this.target = tf;
        }
    }

    protected void Update()
    {
        Following();
    }

    private void Following()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speedCam);
    }
}

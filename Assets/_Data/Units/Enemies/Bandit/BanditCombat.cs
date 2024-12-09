using System;
using UnityEngine;

public class BanditCombat : GameMonoBehaviour
{
    [SerializeField] protected bool detectPlayer;
    [SerializeField] float dir;
    Vector3 posTarget;
    [SerializeField] float dis = 10f;

    protected virtual void Update()
    {
        DetectPlayer();
        //SweepRaycasts(transform.parent.position, distance, angle, numRay, LayerMask.GetMask("Player"));
    }

    private void DetectPlayer()
    {
        //int ignoreLayer = ~(1 << LayerMask.NameToLayer("Enemy") | 1 << LayerMask.NameToLayer("Ignore Raycast"));
        int acceptLayer = 1 << LayerMask.NameToLayer("Ground") | 1<< LayerMask.NameToLayer("Player");
        dir = transform.parent.localScale.x;
        posTarget = new Vector2(dir * dis, transform.parent.position.y);
        RaycastHit2D ray = Physics2D.Raycast(transform.parent.position, posTarget, dis, acceptLayer);

        Debug.DrawRay(transform.parent.position, posTarget);
        if (ray.collider != null)
        {
            detectPlayer = (ray.collider.gameObject.layer == LayerMask.NameToLayer("Player"));
        }
        else detectPlayer = false;
    }

    //private void Test()
    //{
    //    int acceptLayer = 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Player");
    //    dir = transform.parent.localScale.x;
    //    posTarget = GameObject.FindGameObjectWithTag("Player").transform.position;
    //    RaycastHit2D ray = Physics2D.Raycast(transform.parent.position, posTarget - transform.parent.position, dis, acceptLayer);
    //    if (ray.collider != null && ray.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        detectPlayer = true;
    //        if (detectPlayer) Debug.DrawRay(transform.parent.position, posTarget);
    //    }
    //    else detectPlayer = false;
    //}
}

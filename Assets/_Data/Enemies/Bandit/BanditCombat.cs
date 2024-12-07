using System;
using UnityEngine;

public class BanditCombat : GameMonoBehaviour
{
    [SerializeField] protected bool detectPlayer;
    float dir;
    Vector2 posTarget;

    protected virtual void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        dir = transform.parent.localScale.x;
        posTarget = new Vector2(dir * 5 + transform.position.x, transform.position.y);
        //detectPlayer = Physics2D.Raycast(transform.parent.position,
        //    new Vector2(dir, 0), posTarget.x, LayerMask.NameToLayer("Player"));
        RaycastHit2D[] physics = Physics2D.RaycastAll(transform.parent.position, posTarget, posTarget.x, LayerMask.NameToLayer("Player"));
        foreach(var tmp in physics) {
            Debug.Log(tmp.transform.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.parent.position, posTarget);
    }
}

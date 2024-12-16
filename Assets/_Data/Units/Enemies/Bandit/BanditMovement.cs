using System;
using System.Collections;
using UnityEngine;

public class BanditMovement : GameMonoBehaviour
{
    [Header("Load components")]
    Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CheckTerrain checkTerrain;


    [Header("Movement setting")]
    [SerializeField] bool canMove;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] bool moving = true;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigibody();
        LoadCheckTerrain();
        anim = GetComponent<Animator>();
    }

    private void LoadCheckTerrain()
    {
        if (checkTerrain != null) return;
        checkTerrain = transform.Find("CheckTerrain").GetComponent<CheckTerrain>();
        Debug.LogWarning(transform.name + ": LoadCheckTerrain", gameObject);
    }

    protected virtual void Update()
    {
        anim.SetBool(AnimStrings.isMoving, moving);
        CheckGround();
        OnMovement();
    }

    private void CheckGround()
    {
        canMove = checkTerrain.IsGrounded() && !checkTerrain.IsWall();
    }

    private void LoadRigibody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void OnMovement()
    {
        if (moving) rb.linearVelocityX = moveSpeed * transform.localScale.x;
        else rb.linearVelocityX = 0;
        if (!canMove)
        {
            moving = false;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            StartCoroutine(StopMoving());
        }
    }

    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(1f);
        moving = true;
    }



}

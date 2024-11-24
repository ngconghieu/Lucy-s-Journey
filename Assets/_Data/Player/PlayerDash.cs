using System;
using System.Collections;
using UnityEngine;

public class PlayerDash : PlayerAbstract
{
    [SerializeField] protected PlayerJump playerJump;
    [SerializeField] protected float dashSpeed;
    [SerializeField] protected float dashTime;
    [SerializeField] protected float dashCooldown;

    protected Rigidbody2D rb;
    protected float gravity;
    protected bool canDash;
    protected bool dashed;

    protected virtual void Update()
    {
        this.StartDash();
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.rb = PlayerCtrl.Rigidbody2D;
        this.gravity = rb.gravityScale;
        this.LoadPlayerJump();
    }

    private void LoadPlayerJump()
    {
        if (playerJump != null) return;
        this.playerJump = transform.parent.GetComponentInChildren<PlayerJump>();
        Debug.LogWarning(transform.name + ": LoadPlayerJump", gameObject);
    }

    protected void StartDash()
    {
        if(Input.GetButtonDown("Horizontal") && canDash && !dashed)
        {
            StartCoroutine(Dash());
            dashed = true;
        }
        if (playerJump.Grounded())
        {
            dashed = false;
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        PlayerCtrl.dashing = true;
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = gravity;
        PlayerCtrl.dashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}

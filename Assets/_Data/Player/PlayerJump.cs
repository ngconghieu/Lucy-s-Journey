using System;
using UnityEngine;

public class PlayerJump : PlayerAbstract
{
    [Header("Setting jump")]
    [SerializeField] protected float jumpForce = 25;
    [Header("Setting jumping")]
    //jumpBuffer
    protected float jumpBufferCnt = 0;
    [SerializeField] protected float jumpBufferFrames = 1;
    //coyoteTime
    protected float coyoteTimeCnt = 0;
    [SerializeField] protected float coyoteTime = 0.1f;
    //chekc ground
    [Header("Check ground")]
    [SerializeField] protected float groundCheckY = 0.2f;
    [SerializeField] protected float groundCheckX = 0.2f;
    [SerializeField] protected LayerMask isGround;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLayerMask();
    }

    private void LoadLayerMask()
    {
        isGround = LayerMask.GetMask("Ground");
    }

    public bool Grounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckY, isGround)
            || Physics2D.Raycast(transform.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, isGround)
            || Physics2D.Raycast(transform.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, isGround);
    }


    protected virtual void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * groundCheckY, Color.red);
        Debug.DrawRay(transform.position + new Vector3(groundCheckX, 0, 0), Vector2.down * groundCheckY, Color.red);
        Debug.DrawRay(transform.position + new Vector3(-groundCheckX, 0, 0), Vector2.down * groundCheckY, Color.red);
        Debug.Log(transform.name);
        //this.Test();
        this.UpdateJumpVar();
        this.Jump();
    }

    protected virtual void Test()
    {
        if (Input.GetButtonDown("Jump")) PlayerCtrl.Rigidbody2D.linearVelocityY = jumpForce;
    }

    private void Jump()
    {
        Rigidbody2D rb = PlayerCtrl.Rigidbody2D;
        if (Input.GetButtonUp("Jump") && rb.linearVelocityY > 0)
        {
            rb.linearVelocityY = 0;
            PlayerCtrl.jumping = false;
        }

        if (!PlayerCtrl.jumping)
        {
            if (jumpBufferCnt > 0 && coyoteTimeCnt > 0)
            {
                this.Jumping(rb);
                PlayerCtrl.jumping = true;
                PlayerCtrl.doubleJump = true;
            }

            else if (!Grounded() && PlayerCtrl.doubleJump && Input.GetButtonDown("Jump"))
            {
                PlayerCtrl.jumping = true;
                jumpForce = jumpForce * 3 / 4;
                this.Jumping(rb);
                jumpForce = jumpForce * 4 / 3;
                PlayerCtrl.doubleJump = false;
            }
        }


    }

    private void Jumping(Rigidbody2D rb)
    {
        rb.linearVelocityY = jumpForce;
    }

    protected void UpdateJumpVar()
    {
        if (Grounded())
        {
            PlayerCtrl.jumping = false;
            PlayerCtrl.doubleJump = false;
            coyoteTimeCnt = coyoteTime;
        }
        else
        {
            coyoteTimeCnt -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCnt = jumpBufferFrames;
        }
        else
        {
            jumpBufferCnt = jumpBufferCnt - Time.deltaTime * 10;
        }
    }
}

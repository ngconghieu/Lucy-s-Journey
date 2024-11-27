using System;
using UnityEngine;

public class PlayerJump : PlayerAbstract
{
    bool canDoubleJump;
    [Header("Setting jump")]
    [SerializeField] protected float jumpForce = 18;
    [Header("Setting jumping")]
    //jumpBuffer
    protected float jumpBufferCnt = 0;
    [SerializeField] protected float jumpBufferFrames = 1;
    //coyoteTime
    protected float coyoteTimeCnt = 0;
    [SerializeField] protected float coyoteTime = 0.15f;
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
        this.UpdateJumpVar();
        this.Jump();
    }

    private void Jump()
    {
        Rigidbody2D rb = PlayerCtrl.Rigidbody2D;

        if (jumpBufferCnt > 0 && coyoteTimeCnt > 0 && !playerCtrl.PlayerState.Jumping)
        {
            this.Jumping(rb);
            canDoubleJump = true;
        }

        else if (!Grounded() && canDoubleJump && Input.GetButtonDown("Jump"))
        {
            playerCtrl.PlayerState.DoubleJump = true;
            jumpForce = jumpForce * 3 / 4;
            this.Jumping(rb);
            jumpForce = jumpForce * 4 / 3;
            canDoubleJump = false;
        }
    }

    private void Jumping(Rigidbody2D rb)
    {
        playerCtrl.Rigidbody2D.gravityScale = 6;
        rb.linearVelocityY = jumpForce;
        playerCtrl.PlayerState.Jumping = true;
    }

    protected void UpdateJumpVar()
    {
        if (Grounded())
        {
            playerCtrl.PlayerState.Jumping = false;
            playerCtrl.PlayerState.DoubleJump = false;
            canDoubleJump = false;
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
            jumpBufferCnt -= Time.deltaTime * 10;
        }
    }
}
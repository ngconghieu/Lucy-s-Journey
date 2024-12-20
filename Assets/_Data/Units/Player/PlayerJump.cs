using System;
using UnityEngine;

public class PlayerJump : PlayerAbstract
{
    int numOfDoubleJump, maxNumOfDoubleJump = 1;

    [Header("Setting jump")]
    [SerializeField] protected float jumpForce = 18;
    protected float jumpBufferCnt = 0;
    [SerializeField] protected float jumpBufferFrames = 1;
    //coyoteTime
    protected float coyoteTimeCnt = 0;
    [SerializeField] protected float coyoteTime = 0.15f;
    //slide wall
    [Header("Setting slide")]
    [SerializeField] protected float slidingSpeed = 1;

    protected virtual void Update()
    {
        this.UpdateJumpVar();
        this.Jump();
        this.ClimpOnWall();
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.red);
        Debug.DrawRay(transform.position, new Vector2(1 * InputManager.Instance.Move(), 0) * 0.5f, Color.red);
        this.CheckGround();
        this.CheckWall();
    }

    private void CheckWall()
    {
        playerCtrl.IsWall = playerCtrl.CheckWall.IsWall();
    }

    private void CheckGround()
    {
        playerCtrl.IsGrounded = playerCtrl.CheckGround.IsGrounded();
    }

    private void ClimpOnWall()
    {
        if (playerCtrl.IsWall && !playerCtrl.IsGrounded)
        {
            playerCtrl.Rigidbody2D.linearVelocityY = Mathf.Clamp(playerCtrl.Rigidbody2D.linearVelocityY, -slidingSpeed, float.MaxValue);
        }
    }

    private void Jump()
    {
        Rigidbody2D rb = PlayerCtrl.Rigidbody2D;

        if (jumpBufferCnt > 0 && coyoteTimeCnt > 0 && !playerCtrl.Jumping)
        {
            this.Jumping(rb);
        }

        else if (!playerCtrl.IsGrounded && numOfDoubleJump < maxNumOfDoubleJump && InputManager.Instance.Jump())
        {
            numOfDoubleJump++;
            playerCtrl.DoubleJump = true;
            //jumpForce = jumpForce * 4 / 5;
            this.Jumping(rb);
            //jumpForce = jumpForce * 5 / 4;
        }
    }

    private void Jumping(Rigidbody2D rb)
    {
        playerCtrl.Rigidbody2D.gravityScale = 6;
        rb.linearVelocityY = jumpForce;
        playerCtrl.Jumping = true;
    }

    protected void UpdateJumpVar()
    {
        if (playerCtrl.IsGrounded)
        {
            playerCtrl.Jumping = false;
            playerCtrl.DoubleJump = false;
            numOfDoubleJump = 0;
            coyoteTimeCnt = coyoteTime;
        }
        else
        {
            coyoteTimeCnt -= Time.deltaTime;
            //if (playerCtrl.IsWall) numOfDoubleJump = 1;
        }
        if (InputManager.Instance.Jump())
        {
            jumpBufferCnt = jumpBufferFrames;
        }
        else
        {
            jumpBufferCnt -= Time.deltaTime * 10;
        }
    }
}
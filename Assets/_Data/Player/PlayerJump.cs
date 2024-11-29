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
    [Header("Check ground & wall")]
    [SerializeField] protected float groundCheckY = 0.2f;
    [SerializeField] protected float groundCheckX = 0.2f;
    [SerializeField] protected LayerMask ground;
    [SerializeField] protected float slidingSpeed = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLayerMask();
    }

    protected virtual void Update()
    {
        this.UpdateJumpVar();
        this.Jump();
        this.ClimpOnWall();
        this.CheckGround();
        this.CheckWall();
        Debug.DrawRay(transform.position, Vector2.down * groundCheckY, Color.red);
        Debug.DrawRay(transform.position, new Vector2(1 * InputManager.Instance.Move(), 0) * groundCheckX, Color.red);
    }

    private void LoadLayerMask()
    {
        ground = LayerMask.GetMask("Ground");
    }

    public void CheckGround()
    {
        playerCtrl.PlayerState.IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckY, ground);
    }

    private void CheckWall()
    {
        playerCtrl.PlayerState.IsWall = Physics2D.Raycast(transform.position, new Vector2(1 * InputManager.Instance.Move(), 0), groundCheckX, ground);
    }

    private void ClimpOnWall()
    {
        if (playerCtrl.PlayerState.IsWall && !playerCtrl.PlayerState.IsGrounded && InputManager.Instance.Move() != 0)
        {
            playerCtrl.Rigidbody2D.linearVelocityY = Mathf.Clamp(playerCtrl.Rigidbody2D.linearVelocityY, -slidingSpeed, float.MaxValue);
        }
    }

    private void Jump()
    {
        Rigidbody2D rb = PlayerCtrl.Rigidbody2D;

        if (jumpBufferCnt > 0 && coyoteTimeCnt > 0 && !playerCtrl.PlayerState.Jumping)
        {
            this.Jumping(rb);
            canDoubleJump = true;
        }

        else if (!playerCtrl.PlayerState.IsGrounded && canDoubleJump && InputManager.Instance.Jump())
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
        if (playerCtrl.PlayerState.IsGrounded)
        {
            playerCtrl.PlayerState.Jumping = false;
            playerCtrl.PlayerState.DoubleJump = false;
            canDoubleJump = false;
            coyoteTimeCnt = coyoteTime;
        }
        else
        {
            coyoteTimeCnt -= Time.deltaTime;
            if (playerCtrl.PlayerState.IsWall) canDoubleJump = true;
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
using System;
using System.Collections;
using UnityEngine;

public class PlayerJump : PlayerAbstract
{
    int numOfDoubleJump, maxNumOfDoubleJump = 1;

    [Header("Setting jump")]
    [SerializeField] protected float jumpForce = 18;
    protected float jumpBufferCnt = 0;
    [SerializeField] protected float jumpBufferFrames = 1;
    private bool bufferJump;
    //coyoteTime
    protected float coyoteTimeCnt = 0;
    [SerializeField] protected float coyoteTime = 0.15f;
    //slide wall
    [Header("Setting slide")]
    [SerializeField] protected float slidingSpeed = 1;
    [Header("Setting WallJump")]
    [SerializeField] protected float delayWallJump = 0.1f;
    [SerializeField] protected float wallJumpForce = 9;

    private AudioManager audioManager;

    protected virtual void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    protected virtual void Update()
    {
        if (InputManager.Instance.Jump() && InputManager.Instance.JumpDown() == -1) return;
        this.UpdateJumpVar();
        this.Jump();
        //this.ClimpOnWall();
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
        playerCtrl.slideWall = playerCtrl.IsWall && !playerCtrl.IsGrounded && InputManager.Instance.Move() != 0 && playerCtrl.DoubleJump;
        if (playerCtrl.slideWall)
        {
            playerCtrl.Rigidbody2D.linearVelocityY = Mathf.Clamp(playerCtrl.Rigidbody2D.linearVelocityY, -slidingSpeed, float.MaxValue);
            //if (InputManager.Instance.Jump())
            //    StartCoroutine(OnWallJump());
        }
    }

    IEnumerator OnWallJump()
    {
        playerCtrl.wallJump = true;
        WallJump();
        yield return new WaitForSeconds(delayWallJump);
        playerCtrl.wallJump = false;
    }

    private void WallJump()
    {
        playerCtrl.Rigidbody2D.linearVelocity = new Vector2(-InputManager.Instance.Move() * jumpForce, jumpForce);
    }

    private void Jump()
    {
        playerCtrl.Jumping = !playerCtrl.IsGrounded;
        if (jumpBufferCnt > 0 && coyoteTimeCnt > 0 && !bufferJump)
        {
            this.Jumping(playerCtrl.Rigidbody2D);
            //audioManager.PlaySFX(audioManager.jump);
            bufferJump = true;
        }

        else if (!playerCtrl.IsGrounded && numOfDoubleJump < maxNumOfDoubleJump && InputManager.Instance.Jump())
        {
            numOfDoubleJump++;
            playerCtrl.DoubleJump = true;
            jumpForce = jumpForce * 4 / 5;
            this.Jumping(playerCtrl.Rigidbody2D);
            //audioManager.PlaySFX(audioManager.jump);
            jumpForce = jumpForce * 5 / 4;
        }
    }

    private void Jumping(Rigidbody2D rb)
    {
        playerCtrl.Rigidbody2D.gravityScale = 6;
        rb.linearVelocityY = jumpForce;
    }

    protected void UpdateJumpVar()
    {
        if (playerCtrl.IsGrounded)
        {
            playerCtrl.Jumping = false;
            playerCtrl.DoubleJump = false;
            numOfDoubleJump = 0;
            coyoteTimeCnt = coyoteTime;
            bufferJump = false;
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
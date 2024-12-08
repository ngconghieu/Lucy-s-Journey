using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnim : PlayerAbstract
{
    protected void Update()
    {
        this.Anim();
    }

    private void Anim()
    {
        //moving
        float moving = playerCtrl.PlayerState.Moving;
        playerCtrl.Animator.SetFloat(AnimStrings.isMoving, Mathf.Abs(moving));

        //jumping
        bool jumping = playerCtrl.PlayerState.Jumping;
        playerCtrl.Animator.SetBool(AnimStrings.isJumping, jumping);

        //double jumping
        bool doubleJump = playerCtrl.PlayerState.DoubleJump;
        playerCtrl.Animator.SetBool(AnimStrings.isDoubleJump, doubleJump);

        //dashing
        bool dashing = playerCtrl.PlayerState.Dashing;
        playerCtrl.Animator.SetBool(AnimStrings.isDashing, dashing);

        //attacking

        //slide wall
        bool slideWall = playerCtrl.PlayerState.IsWall && !playerCtrl.PlayerState.IsGrounded;
        playerCtrl.Animator.SetBool(AnimStrings.isSlideWall, slideWall);
    }
}
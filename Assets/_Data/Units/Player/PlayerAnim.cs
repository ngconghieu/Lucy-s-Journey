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
        float moving = playerCtrl.Moving;
        playerCtrl.Animator.SetFloat(AnimStrings.isMoving, Mathf.Abs(moving));

        //jumping
        bool jumping = playerCtrl.Jumping;
        playerCtrl.Animator.SetBool(AnimStrings.isJumping, jumping);

        //double jumping
        bool doubleJump = playerCtrl.DoubleJump;
        playerCtrl.Animator.SetBool(AnimStrings.isDoubleJump, doubleJump);

        //slide wall
        bool slideWall = playerCtrl.slideWall;
        playerCtrl.Animator.SetBool(AnimStrings.isSlideWall, slideWall);

        //dashing
        bool dashing = playerCtrl.Dashing;
        playerCtrl.Animator.SetBool(AnimStrings.isDashing, dashing);
    }

    ////dashing
    //public void TriggerDash()
    //{
    //    playerCtrl.Animator.SetTrigger(AnimStrings.isDashing);
    //}

    //attacking
    public void TriggerAttack(int comboIndex)
    {
        switch (comboIndex)
        {
            case 0:
                playerCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
                break;
            case 1:
                playerCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack1);
                break;
            case 2:
                playerCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
                break;
        }
    }

    //hit
    public void TriggerHit()
    {
        playerCtrl.Animator.SetTrigger(AnimStrings.isHit);
    }

    //dead
    public void TriggerDead()
    {
        playerCtrl.Animator.SetTrigger(AnimStrings.isDead);
    }
}
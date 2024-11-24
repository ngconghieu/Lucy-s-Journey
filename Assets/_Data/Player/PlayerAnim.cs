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
        float moving = InputManager.Instance.XAxis;
        playerCtrl.Animator.SetFloat("Moving", Mathf.Abs(moving));

        //jumping
        bool jumping = playerCtrl.jumping;
        playerCtrl.Animator.SetBool("Jumping", jumping);

        //double jumping
        bool doubleJump = playerCtrl.doubleJump;
        playerCtrl.Animator.SetBool("DoubleJump", doubleJump);
    }
}



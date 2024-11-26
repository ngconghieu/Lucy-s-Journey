using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerEffect : PlayerAbstract
{
    bool dashed;
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

        //dashing
        bool dashing = playerCtrl.dashing;
        playerCtrl.Animator.SetBool("Dashing", dashing);
        if (dashing && !dashed) {
            Transform smoke = transform.parent.Find("Dash").Find("Smoke");
            Quaternion smokeRot = transform.parent.rotation;
            Transform setDir = FXSpawner.Instance.Spawn(FXSpawner.DashSmoke, smoke.position, smokeRot);
            setDir.localScale = transform.parent.localScale;
            dashed = true;
        }
        if (!dashing) dashed = false;
    }
}



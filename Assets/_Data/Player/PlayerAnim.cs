using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnim : PlayerAbstract
{
    [SerializeField] float timer = 0;
    [SerializeField] float smokeCd = 0.3f;
    protected void FixedUpdate()
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

        timer += Time.fixedDeltaTime;
        if (timer >= smokeCd && dashing == true)
        {
            timer = 0;
            Transform smoke = transform.parent.Find("Dash").Find("Smoke");
            Quaternion smokeRot = transform.parent.rotation;
            Transform setDir = FXSpawner.Instance.Spawn(FXSpawner.DashSmoke, smoke.position, smokeRot);
            setDir.localScale = transform.parent.localScale;
            smoke = setDir;
        }
    }
}



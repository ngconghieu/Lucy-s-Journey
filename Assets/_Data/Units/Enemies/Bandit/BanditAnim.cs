using System;
using UnityEngine;

public class BanditAnim : BanditAbstract
{
    protected virtual void Update()
    {
        Anim();
    }

    private void Anim()
    {
        BanditCtrl.Animator.SetBool(AnimStrings.isMoving, BanditCtrl.moving);
    }

    public void TriggerHit()
    {
        BanditCtrl.Animator.SetTrigger(AnimStrings.isHit);
    }

    public void TriggerAttack()
    {
        BanditCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
    }
}

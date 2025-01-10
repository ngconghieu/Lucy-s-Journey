using System;
using UnityEngine;

public class HuntressAnim : HuntressAbstract
{
    protected virtual void Update()
    {
        Anim();
    }

    private void Anim()
    {
        HuntressCtrl.Animator.SetBool(AnimStrings.isMoving, HuntressCtrl.moving);
    }
    public void TriggerDead()
    {
        HuntressCtrl.Animator.SetTrigger(AnimStrings.isDead);
    }

    public void TriggerHit()
    {
        HuntressCtrl.Animator.SetTrigger(AnimStrings.isHit);
    }

    public void TriggerAttack()
    {
        HuntressCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
    }

    public void TriggerSpecialAttack()
    {
        HuntressCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack2);
    }
}

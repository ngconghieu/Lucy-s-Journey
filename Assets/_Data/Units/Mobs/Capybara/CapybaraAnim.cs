using System;
using UnityEngine;

public class CapybaraAnim : CapybaraAbstract
{
    protected virtual void Update()
    {
        Anim();
    }

    private void Anim()
    {
        CapybaraCtrl.Animator.SetBool(AnimStrings.isMoving, CapybaraCtrl.moving);
    }

    public void TriggerDead()
    {
        CapybaraCtrl.Animator.SetTrigger(AnimStrings.isDead);
    }
}

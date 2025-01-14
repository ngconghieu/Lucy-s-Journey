using UnityEngine;

public class DeathAnim : DeathAbstract
{
    protected virtual void Update()
    {
        Anim();
    }

    private void Anim()
    {
        DeathCtrl.Animator.SetBool(AnimStrings.isMoving, DeathCtrl.moving);
    }
    public void TriggerDead()
    {
        DeathCtrl.Animator.SetTrigger(AnimStrings.isDead);
    }

    public void TriggerHit()
    {
        DeathCtrl.Animator.SetTrigger(AnimStrings.isHit);
    }

    public void TriggerAttack()
    {
        DeathCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack0);
    }

    public void TriggerSpecialAttack()
    {
        DeathCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack1);
    }

    public void TriggerSpecialAttack1()
    {
        DeathCtrl.Animator.SetTrigger(AnimStrings.isNormalAttack2);
    }
}

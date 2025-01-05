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

    public void TriggerDead()
    {
        BanditCtrl.Animator.SetTrigger(AnimStrings.isDead);
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
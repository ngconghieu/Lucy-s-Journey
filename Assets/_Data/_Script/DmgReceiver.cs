using System;
using UnityEngine;

public abstract class DmgReceiver : GameMonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 1;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }

    public virtual void Reborn()
    {
        hp = maxHp;
    }

    public virtual void Add(int add)
    {
        if (CheckDead()) return;
        hp += add;
        if (hp > maxHp) hp = maxHp;
    }

    public virtual void Deduct(int deduct)
    {
        if (CheckDead()) return;
        hp -= deduct;
        if (hp < deduct) hp = 0;
        this.IsDead();
    }

    protected virtual void IsDead()
    {
        if (!this.CheckDead()) return;
        this.OnDead();
    }

    protected abstract void OnDead();

    protected virtual bool CheckDead()
    {
        return hp <= 0;
    }
}

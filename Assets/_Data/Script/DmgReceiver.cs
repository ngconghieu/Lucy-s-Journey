using System;
using UnityEngine;

public abstract class DmgReceiver : GameMonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 1;

    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }

    public void Reborn()
    {
        hp = maxHp;
    }

    public void Add(int add)
    {
        if (CheckDead()) return;
        hp += add;
        if (hp > maxHp) hp = maxHp;
    }

    public void Deduct(int deduct)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(transform.name + " " + collision);
    }
}

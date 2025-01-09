using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DmgReceiver : GameMonoBehaviour
{
    public event Action<LayerMask> OnHurt; //event collider
    public event Action OnDead;
    
    [SerializeField] Collider2D _collider;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected BaseStatsSO stats;
    private HealthManager healthManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
        healthManager = FindAnyObjectByType<HealthManager>();
        if (healthManager != null)
        {
            healthManager.SetMaxHealth(maxHp);
        }
        Debug.Log("DmgReceiver component loaded on " + gameObject.name);
    }

    private void LoadCollider()
    {
        if (_collider != null) return;
        _collider = transform.GetComponent<Collider2D>();
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void Dead()
    {
        _collider.enabled = false;
        OnDead?.Invoke();
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
        if (healthManager != null)
        {
            healthManager.SetHealth(hp);
        }
    }

    public virtual void Deduct(int deduct)
    {
        if (CheckDead()) return;
        Debug.Log("Deduct: " + deduct);
        hp -= deduct;
        if (hp < deduct) hp = 0;
        if (healthManager != null)
        {
            healthManager.SetHealth(hp);
        }
        this.IsDead();
    }
    
    protected virtual void IsDead()
    {
        if (!this.CheckDead()) return;
        this.Dead();
    }

    public virtual void SetMaxHp(int maxHp)
    {
        this.maxHp = maxHp;
        if (healthManager != null)
        {
            healthManager.SetMaxHealth(maxHp);
        }
    }

    protected virtual bool CheckDead()
    {
        return hp <= 0;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnHurt?.Invoke(collision.gameObject.layer);//detect collider
    }
}

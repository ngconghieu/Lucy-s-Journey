using System;
using UnityEngine;

public class DmgReceiver : GameMonoBehaviour
{
    public event Action<LayerMask> OnHurt; //event collider
    public event Action OnDead;
    
    [SerializeField] Collider2D _collider;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 1;
    AudioManager audioManager;
    protected virtual void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public int GetHp()
    {
       return hp;
    }
    public int GetMaxHp()
    {
        return maxHp;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
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
    }

    public virtual void Deduct(int deduct)
    {
        if (CheckDead()) return; // Kiểm tra xem nhân vật có chết không

        int previousHp = hp; // Lưu giá trị HP trước khi trừ
        hp -= deduct; // Giảm HP
        if (hp < 0) hp = 0; // Đảm bảo HP không nhỏ hơn 0

        if (hp < previousHp) // Kiểm tra nếu HP đã giảm
        {
            audioManager.SFXVolume = 0.5f;
            audioManager.PlaySFX(audioManager.hurt); // Gọi âm thanh khi nhận sát thương
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
    }

    protected virtual bool CheckDead()
    {
        return hp <= 0;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnHurt?.Invoke(collision.gameObject.layer);//detect collider
        //audioManager.PlaySFX(audioManager.hurt);
    }
}

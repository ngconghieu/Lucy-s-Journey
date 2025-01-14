using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class DmgReceiver : GameMonoBehaviour
{
    public event Action<LayerMask> OnHurt; //event collider
    public event Action OnDead;
    public PauseManager gameO;
    
    [SerializeField] Collider2D _collider;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 1;
    [SerializeField] protected bool isPlayer = false;
    [SerializeField] protected bool isBossFinal = false;

    AudioManager audioManager;
    protected override void Awake()
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
        if (CheckDead()) return;

        int previousHp = hp;
        hp -= deduct;
        if (hp < 0) hp = 0;

        if (hp < previousHp)
        {
            audioManager.SFXVolume = 0.5f;
            audioManager.PlaySFX(audioManager.hurt);
        }

        this.IsDead();
    }

    protected virtual void IsDead()
    {
        if (!this.CheckDead()) return;
        this.Dead();
        audioManager.StopBackgroundMusic();
        if (isPlayer)
        {
            gameO.gameOver();
            audioManager.PlaySFX(audioManager.lose);
            Time.timeScale = 0f;
        }
        if (isBossFinal)
        {
            gameO.gameWin();
            audioManager.PlaySFX(audioManager.win);
            Time.timeScale = 0f;
        }

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
    }
    
}

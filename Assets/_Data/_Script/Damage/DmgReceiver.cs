using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class DmgReceiver : GameMonoBehaviour
{
    public event Action<LayerMask> OnHurt; //event collider
    public event Action OnDead;
    
    [SerializeField] Collider2D _collider;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 1;
    [SerializeField] protected bool isPlayer = false;

    private static int totalEnemies = 0;
    private static int deadEnemies = 0;
    private void Start()
    {
        if (!isPlayer)
        {
            totalEnemies++;
        }
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
        if (!isPlayer)
        {
            deadEnemies++;
            CheckWinCondition();
        }

    }
    //quai chet het va isplayer khong chet thì win(scen4)
    private void CheckWinCondition()
    {
        if (deadEnemies >= totalEnemies && GameObject.FindObjectsOfType<DmgReceiver>().Any(x => x.isPlayer && !x.CheckDead()))
        {
            PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadSceneAsync(4); // Win scene
        }
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
        this.Dead();
        if (isPlayer)
        {
            PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadSceneAsync(3);
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
    
    private void OnDestroy()
    {
        if (!isPlayer)
        {
            totalEnemies--;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStatics()
    {
        totalEnemies = 0;
        deadEnemies = 0;
    }
}

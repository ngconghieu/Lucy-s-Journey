using UnityEngine;

public class PlayerReceiver : DmgReceiver
{
    [SerializeField] protected PlayerSO playerSO;
    [SerializeField] protected HealthManager healthManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerOS();
        LoadHealthBar();
    }

    private void LoadPlayerOS()
    {
        if (playerSO != null) return;
        playerSO = GetComponent<PlayerSO>();
        if (playerSO == null)
        {
            Debug.LogWarning(transform.name + ": playerSO not found", gameObject);
        }
        else
        {
            hp = playerSO.hpMax;
            maxHp = playerSO.hpMax;
        }
    }
    private void LoadHealthBar()
    {
        if (healthManager != null) return;
        healthManager = GetComponentInChildren<HealthManager>();
        if (healthManager == null)
        {
            Debug.LogWarning(transform.name + ": healthManager not found", gameObject);
        }
    }

    public override void Reborn()
    {
        base.Reborn();    
        UpdateHealthBar();
    }

    public override void Add(int add)
    {
        base.Add(add);       
        UpdateHealthBar();
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        UpdateHealthBar();
    }

    public override void SetMaxHp(int maxHp)
    {
        base.SetMaxHp(maxHp);    
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthManager != null)
        {
            healthManager.SetHealth(hp);
        }
    }
}

using UnityEngine;

public class PlayerState : GameMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected override void Start()
    {
        base.Start();
        //load hp
        playerCtrl.DmgReceiver.SetMaxHp(playerCtrl.PlayerSO.hpMax);
        playerCtrl.DmgReceiver.Reborn();
        playerCtrl.HealthManager.SetMaxHealth(playerCtrl.DmgReceiver.GetMaxHp());
        //register event
        playerCtrl.DmgReceiver.OnHurt += HandleHurt;
        playerCtrl.DmgReceiver.OnDead += HandleDead;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        playerCtrl.DmgReceiver.OnHurt -= HandleHurt;
        playerCtrl.DmgReceiver.OnDead -= HandleDead;
    }

    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = GetComponent<PlayerCtrl>();
        Debug.LogWarning("LoadPlayerCtrl", gameObject);
    }

    private void HandleHurt(LayerMask layerMask)
    {
        if (layerMask == LayerMask.NameToLayer("Enemy") ||
            layerMask == LayerMask.NameToLayer("Trap"))
        {
            playerCtrl.PlayerAnim.TriggerHit();
            if (playerCtrl.HealthManager != null)
            {
                playerCtrl.HealthManager.SetHealth(playerCtrl.DmgReceiver.GetHp());

            }
        }
    }

    private void HandleDead()
    {
        playerCtrl.PlayerAnim.TriggerDead();
    }

   
}
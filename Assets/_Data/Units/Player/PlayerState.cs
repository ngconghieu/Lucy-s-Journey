using System;
using System.Collections;
using UnityEngine;

public class PlayerState : GameMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    [SerializeField] GameObject oneWayPlatform;

    #region Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = GetComponent<PlayerCtrl>();
        Debug.LogWarning("LoadPlayerCtrl", gameObject);
    }
    #endregion

    protected override void Start()
    {
        base.Start();
        //load hp
        playerCtrl.DmgReceiver.SetMaxHp(playerCtrl.PlayerSO.hpMax);
        playerCtrl.DmgReceiver.Reborn();
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

    private void HandleHurt(LayerMask layerMask)
    {
        if (layerMask == LayerMask.NameToLayer("Enemy") ||
            layerMask == LayerMask.NameToLayer("Trap") ||
            layerMask == LayerMask.NameToLayer("Projectile"))
        {
            playerCtrl.PlayerAnim.TriggerHit();
        }
    }

    private void HandleDead()
    {
        StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        playerCtrl.PlayerAnim.TriggerDead();
        playerCtrl.dead = true;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    #region Handle JumpDown
    private void Update()
    {
        if (playerCtrl.Dashing)
            playerCtrl.DmgReceiver.Collider.enabled = false;
        else
            playerCtrl.DmgReceiver.Collider.enabled = true;

        if (Input.GetButton("Jump") && InputManager.Instance.JumpDown() == -1)
            if (oneWayPlatform != null)
                StartCoroutine(OnJumpDown());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
            oneWayPlatform = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
            oneWayPlatform = null;
    }

    IEnumerator OnJumpDown()
    {
        Collider2D platformCollider = oneWayPlatform.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(playerCtrl.CapsuleCollider, platformCollider);
        yield return new WaitForSeconds(0.4f);
        Physics2D.IgnoreCollision(playerCtrl.CapsuleCollider, platformCollider, false);
    }
    #endregion
}
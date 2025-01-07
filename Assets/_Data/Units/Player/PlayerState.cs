using System;
using System.Collections;
using UnityEngine;

public class PlayerState : GameMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    [SerializeField] PlatformEffector2D EffectorToJumpDown;

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
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    LoadEffectorForJumpDown(collision);
    //    if (EffectorToJumpDown != null && collision.gameObject.CompareTag("OneWayTerrain") && CanJumpDown())
    //    {
    //        Debug.Log("On Jump Down");
    //        StartCoroutine(OnJumpDown());
    //    }
    //    }
    //    IEnumerator OnJumpDown()
    //{
    //    EffectorToJumpDown.rotationalOffset = 180;
    //    yield return new WaitForSeconds(1);
    //}
    //private bool CanJumpDown() => Input.GetButton("Jump") && InputManager.Instance.JumpDown() == -1;

    //private void LoadEffectorForJumpDown(Collision2D collision)
    //{
    //    if (EffectorToJumpDown == null)
    //    {
    //        if (collision.gameObject.TryGetComponent(out PlatformEffector2D platformEffector))
    //            EffectorToJumpDown = platformEffector;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (EffectorToJumpDown != null)
    //        EffectorToJumpDown.rotationalOffset = 0;
    //}
    GameObject oneWayPlatform;
    private void Update()
    {
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
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCtrl.CapsuleCollider, platformCollider, false);
    }
    #endregion
}
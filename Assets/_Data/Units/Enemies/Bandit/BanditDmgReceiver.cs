using System;
using System.Collections;
using UnityEngine;

public class BanditDmgReceiver : DmgReceiver
{
    [SerializeField] Animator anim;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] BanditCtrl banditState;
    [SerializeField] protected float cdToDespawn = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnim();
        LoadCollider();
        LoadBanditCtrl();
    }

    private void LoadBanditCtrl()
    {
        if (banditState != null) return;
        banditState = transform.parent.GetComponent<BanditCtrl>();
        Debug.LogWarning(transform.name + ": LoadBanditCtrl", gameObject);
    }

    private void LoadCollider()
    {
        if (_collider != null) return;
        _collider = transform.GetComponent<BoxCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    private void LoadAnim()
    {
        if (this.anim != null) return;
        this.anim = transform.parent.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnim", gameObject);
    }

    public override void Reborn()
    {
        this.maxHp = banditState.EnemiesSO.hpMax;
        base.Reborn();
    }

    protected override void OnDead()
    {
        _collider.enabled = false;
        DropManager.Instance.Drop(banditState.EnemiesSO.dropList);
        anim.SetTrigger(AnimStrings.isDead);
        StartCoroutine(DespawnAfterTime());
    }

    private IEnumerator DespawnAfterTime()
    {
        yield return new WaitForSeconds(cdToDespawn);
        transform.parent.gameObject.SetActive(false);
        _collider.enabled = true;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.layer + " "+ LayerMask.NameToLayer("Player"));
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collision.TryGetComponent<PlayerCombat>(out _)) anim.SetTrigger(AnimStrings.isHit);
        }
    }
}
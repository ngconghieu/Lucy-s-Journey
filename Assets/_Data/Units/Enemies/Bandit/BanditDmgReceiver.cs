using System;
using System.Collections;
using UnityEngine;

public class BanditDmgReceiver : DmgReceiver
{
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] BanditCtrl banditCtrl;
    [SerializeField] protected float cdToDespawn = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
        LoadBanditCtrl();
    }

    private void LoadBanditCtrl()
    {
        if (banditCtrl != null) return;
        banditCtrl = transform.parent.GetComponent<BanditCtrl>();
        Debug.LogWarning(transform.name + ": LoadBanditCtrl", gameObject);
    }

    private void LoadCollider()
    {
        if (_collider != null) return;
        _collider = transform.GetComponent<BoxCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    public override void Reborn()
    {
        this.maxHp = banditCtrl.EnemiesSO.hpMax;
        base.Reborn();
    }

    protected override void OnDead()
    {
        _collider.enabled = false;
        DropManager.Instance.Drop(banditCtrl.EnemiesSO.dropList);
        banditCtrl.BanditAnim.TriggerDead();
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
            if (collision.TryGetComponent<PlayerCombat>(out _)) banditCtrl.BanditAnim.TriggerHit();
        }
    }
}
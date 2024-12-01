using System;
using System.Collections;
using UnityEngine;

public class SnailDmgReceiver : DmgReceiver
{
    [SerializeField] Animator anim;
    [SerializeField] protected float cdToDespawn = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnim();
    }

    private void LoadAnim()
    {
        if (this.anim != null) return;
        this.anim = transform.parent.Find("Model").GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnim", gameObject);
    }

    protected override void OnDead()
    {
        anim.SetTrigger("Dead");
        StartCoroutine(DespawnAfterTime());
    }

    private IEnumerator DespawnAfterTime()
    {
        yield return new WaitForSeconds(cdToDespawn);
        transform.parent.gameObject.SetActive(false);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxHp = 8;
    }
}

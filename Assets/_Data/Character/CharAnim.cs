using System;
using Unity.Mathematics;
using UnityEngine;

public class CharAnim : GameMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnim();
    }

    protected void LoadAnim()
    {
        if (this.anim != null) return;
        this.anim = GetComponentInParent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnim", gameObject);
    }
    protected void FixedUpdate()
    {
        this.Moving();
    }

    private void Moving()
    {
        float tmp = InputManager.Instance.MovementInput.x;
        anim.SetFloat("Moving", Mathf.Abs(tmp));
    }
}



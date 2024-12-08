using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : PlayerAbstract
{
    Animator animator;
    [Header("Combo attack setting")]
    [SerializeField] private bool isComboActive;
    [SerializeField] private float maxComboTime = 1.5f;
    [SerializeField] private int comboIndex = 0;
    [SerializeField] private float comboTimer = 0;
    public bool canNextCombo = true;// check on animation

    [Header("Setting send dmg")]
    [SerializeField] protected int dmg = 2;
    int oDmg;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        oDmg = dmg;
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleComboAttack();
        UpdateComboTimer();
    }

    private void HandleComboAttack()
    {
        if (InputManager.Instance.Attack() && canNextCombo)
        {
            if (comboIndex > 2)
            {
                ResetCombo();
                return;
            }
            PerformAttack();
        }
    }

    private void PerformAttack()
    {

        // update combo state
        comboTimer = maxComboTime;
        isComboActive = true;

        // Start attack combo
        Attack();
        comboIndex++;

    }

    private void Attack()
    {
        if (comboIndex == 0) animator.SetTrigger(AnimStrings.isNormalAttack0);
        else if (comboIndex == 1)
        {
            dmg += dmg;
            animator.SetTrigger(AnimStrings.isNormalAttack1);
        }
        else
        {
            dmg += dmg;
            animator.SetTrigger(AnimStrings.isNormalAttack2);
        }
    }

    private void UpdateComboTimer()
    {
        if (isComboActive)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                ResetCombo();
            }
        }
    }

    private void ResetCombo()
    {
        dmg = oDmg;
        isComboActive = false;
        comboIndex = 0;
        comboTimer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            DmgReceiver dmgReceiver = collision.GetComponent<DmgReceiver>();
            dmgReceiver.Deduct(dmg);
        }
    }

}

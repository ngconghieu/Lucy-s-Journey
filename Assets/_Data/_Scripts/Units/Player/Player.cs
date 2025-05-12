using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : UnitBase
{
    [SerializeField] private CapsuleCollider2D _colliderStatic;
    [SerializeField] private PlayerStateMachine _stateMachine;

    [Header("Player techinical")]
    [SerializeField] private float _gravityScale = 2f;
    [SerializeField] private Vector2 _colliderStaticSize = new(0.5f, 2.07f);
    [SerializeField] private Vector2 _colliderTriggerSize = new(0.5f, 2.07f);

    public PlayerStats PlayerStats;

    public PlayerStateMachine StateMachine => _stateMachine;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCollider();
        LoadPlayerStateMachine();

        Rigibody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Rigibody.gravityScale = _gravityScale;
    }

    private void LoadCollider()
    {
        //load collider
        var collider = GetComponents<CapsuleCollider2D>();
        if (collider.Length < 2)
        {
            colliderReceivesDmg = collider[0];
            _colliderStatic = gameObject.AddComponent<CapsuleCollider2D>();
        }
        else
        {
            colliderReceivesDmg = collider[0];
            _colliderStatic = collider[1];
        }
        //setup collider

        _colliderStatic.isTrigger = false;
        _colliderStatic.size = _colliderStaticSize;

        if (colliderReceivesDmg is CapsuleCollider2D _colliderTrigger)
        {
            _colliderTrigger.isTrigger = true;
            _colliderTrigger.size = _colliderTriggerSize;
        }
    }

    private void LoadPlayerStateMachine()
    {
        ComponentLoader.LoadComponent(ref _stateMachine, this);
        _stateMachine.Initialize(this);
    }
}

[Serializable]
public struct PlayerStats
{
    public float speed;
    public float jumpForce;
    public float jumpTime;
    public float jumpHeight;
    public float fallSpeed;
    public float maxFallSpeed;
    public float maxJumpTime;
}
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : UnitBase
{
    [SerializeField] private CapsuleCollider2D _colliderStatic;
    [SerializeField] private PlayerStateMachine _stateMachine;
    public PlayerStateMachine StateMachine => _stateMachine;



    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCollider();
        LoadPlayerStateMachine();

        Rigibody.constraints = RigidbodyConstraints2D.FreezeRotation;
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
        _colliderStatic.size = new Vector2(0.5f, 2.07f);

        if (colliderReceivesDmg is CapsuleCollider2D capsuleCollider)
        {
            capsuleCollider.isTrigger = true;
            capsuleCollider.size = new Vector2(0.5f, 2.07f);
        }
    }

    private void LoadPlayerStateMachine()
    {
        LoadComponent(ref _stateMachine, this);
        _stateMachine.Initialize(this);
    }
}
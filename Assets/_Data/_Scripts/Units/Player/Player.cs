using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
public class Player : BaseMonoBehaviour, IUnitBase
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _anim;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private GroundSensor _groundSensor;


    [Header("Player technical")]
    [SerializeField] private float _gravityScale = 4f;
    [SerializeField] private Vector2 _colliderSize = new(0.5f, 2.07f);

    public PlayerStats PlayerStats;

    public Animator Anim => _anim;

    public Collider2D Collider => _collider;

    public Rigidbody2D Rigibody => _rigidbody;

    public PlayerStateMachine StateMachine => _stateMachine;
    public GroundSensor GroundSensor => _groundSensor;

    protected override void Awake()
    {
        base.Awake();
        // anim
        ComponentLoader.LoadComponentInChildren(ref _anim, this);

        // collider
        ComponentLoader.LoadComponent(ref _collider, this);
        _collider.isTrigger = false;
        _collider.size = _colliderSize;

        // rigidbody
        ComponentLoader.LoadComponent(ref _rigidbody, this);
        Rigibody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Rigibody.gravityScale = _gravityScale;

        // state machine
        ComponentLoader.LoadComponent(ref _stateMachine, this);
        _stateMachine.Setup(this);

        // ground sensor
        ComponentLoader.LoadComponentInChildren(ref _groundSensor, this);
        _groundSensor.Setup(_collider);
    }
}


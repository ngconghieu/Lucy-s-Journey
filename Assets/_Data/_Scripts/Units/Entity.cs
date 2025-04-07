using UnityEngine;

public class Entity : Base
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigibody;

    public Animator Anim => _anim;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigibody => _rigibody;

    protected override void LoadComponent()
    {
        LoadComponentInChildren(ref _anim, this);
        LoadComponentInChildren(ref _collider, this);
        LoadComponentInChildren(ref _rigibody, this);
    }
}
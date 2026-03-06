using UnityEngine;

public interface IUnitBase
{
    Animator Anim { get; }
    Collider2D Collider { get; }
    Rigidbody2D Rigibody { get; }
}
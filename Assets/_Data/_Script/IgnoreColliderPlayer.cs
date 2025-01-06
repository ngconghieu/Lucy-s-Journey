using UnityEngine;

public class IgnoreColliderPlayer : GameMonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Collider2D _collider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCollider();
        LoadCollider();
    }

    protected override void Start()
    {
        Physics2D.IgnoreCollision(_collider, playerCollider);
    }

    private void LoadCollider()
    {

        if (_collider != null) return;
        _collider = GetComponent<Collider2D>();
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    private void LoadPlayerCollider()
    {
        if (playerCollider != null) return;
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Debug.LogWarning(transform.name + ": LoadPlayerCollider", gameObject);
    }
}
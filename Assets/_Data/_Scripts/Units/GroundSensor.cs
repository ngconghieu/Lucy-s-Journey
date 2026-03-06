using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private float radiusCheck = 0.1f;
    [SerializeField] private float positionY;
    public LayerMask GroundLayer;
    public bool IsGrounded { get; private set; }

    public void Setup(Collider2D collider)
    {
        positionY = collider.bounds.size.y / 2;
        transform.position = new Vector3(transform.position.x, transform.position.y - positionY, transform.position.z);
    }

    private void FixedUpdate()
    {
        IsGrounded = CheckGround(transform.position, radiusCheck, GroundLayer);
    }

    public bool CheckGround(Vector3 position, float radius, LayerMask groundLayer)
    {

        return Physics2D.OverlapCircle(position, radius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiusCheck);
    }
}
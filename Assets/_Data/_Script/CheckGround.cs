using UnityEngine;

public class CheckGround : GameMonoBehaviour
{
    [Header("Check ground")]
    [SerializeField] protected float PosXAxis = 0f;
    [SerializeField] protected float groundCheckX = 0.45f;
    [SerializeField] protected float groundCheckY = 0.4f;

    public bool IsGrounded()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(new Vector3(transform.parent.localScale.x * PosXAxis + transform.position.x,
            transform.position.y), new Vector2(groundCheckX, groundCheckY), 0, LayerMask.GetMask("Ground"));
        return col.Length > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(transform.parent.localScale.x * PosXAxis + transform.position.x,
            transform.position.y), new Vector2(groundCheckX, groundCheckY));
    }
}

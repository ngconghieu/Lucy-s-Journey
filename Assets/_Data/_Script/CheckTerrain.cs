using UnityEngine;

public class CheckTerrain : GameMonoBehaviour
{
    [Header("Check ground")]
    [SerializeField] protected float PosXAxis = 0.3f;
    [SerializeField] protected float groundCheckX = 0.3f;
    [SerializeField] protected float groundCheckY = 3f;

    [Header("Check wall")]
    [SerializeField] protected float wallCheckX = 1.5f;
    [SerializeField] protected float wallCheckY = 1.4f;

    public bool IsGrounded()
    {
        //return Physics2D.Raycast(transform.position, Vector2.down, groundCheckY, LayerMask.NameToLayer("Ground"));
        Collider2D[] col = Physics2D.OverlapBoxAll(new Vector3(transform.parent.localScale.x * PosXAxis + transform.parent.position.x,
            transform.parent.position.y), new Vector2(groundCheckX, groundCheckY), 0, LayerMask.GetMask("Ground"));
        return col.Length > 0;
    }

    public bool IsWall()
    {
        //return Physics2D.Raycast(transform.position, new Vector2(transform.parent.localScale.x, 0), groundCheckX, LayerMask.GetMask("Ground"));
        Collider2D[] col = Physics2D.OverlapBoxAll(new Vector3(transform.parent.localScale.x * PosXAxis + transform.parent.position.x,
            transform.parent.position.y), new Vector2(wallCheckX, wallCheckY), 0, LayerMask.GetMask("Ground"));
        return col.Length > 0;
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawRay(transform.position, Vector3.down * groundCheckY);
        //Gizmos.DrawRay(transform.position, new Vector2(transform.parent.localScale.x,0));
        Gizmos.DrawWireCube(new Vector3(transform.parent.localScale.x * PosXAxis + transform.parent.position.x,
            transform.parent.position.y), new Vector2(groundCheckX, groundCheckY));
        Gizmos.DrawWireCube(new Vector3(transform.parent.localScale.x * PosXAxis + transform.parent.position.x,
            transform.parent.position.y), new Vector2(wallCheckX, wallCheckY));
    }
}

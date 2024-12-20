using UnityEngine;

public class CheckWall : GameMonoBehaviour
{
    [Header("Check wall")]
    [SerializeField] protected float wallCheckX = 1.5f;
    [SerializeField] protected float wallCheckY = 1.4f;

    public bool IsWall()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(new Vector3(transform.position.x,
            transform.position.y), new Vector2(wallCheckX, wallCheckY), 0, LayerMask.GetMask("Ground"));
        return col.Length > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y),
            new Vector2(wallCheckX, wallCheckY));
    }
}

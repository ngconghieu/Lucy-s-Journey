using UnityEngine;

public class DetectPlayer : GameMonoBehaviour
{
    public bool DetectPlayerForFlying(float detectPlayerRange, GameObject posPlayer)
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.parent.position, (posPlayer.transform.position - transform.parent.position).normalized, detectPlayerRange, 
            ~LayerMask.GetMask("OneWayPlatform", "Ignore Raycast"));
        Debug.DrawRay(transform.parent.position, (posPlayer.transform.position - transform.parent.position).normalized * detectPlayerRange);
        if (raycast.collider == null)
            return false;
        //Debug.Log(raycast.collider.name, gameObject);
        return raycast.transform.CompareTag("Player");
    }

    public bool DetectPlayerForGround(float detectPlayerRange)
    {
        //Shot a ray
        RaycastHit2D[] raycast = Physics2D.LinecastAll(transform.parent.position - new Vector3(detectPlayerRange, 0),
            transform.parent.position + new Vector3(detectPlayerRange, 0));
        //Draw a ray
        Debug.DrawLine(transform.parent.position - new Vector3(detectPlayerRange, 0),
            transform.parent.position + new Vector3(detectPlayerRange, 0));
        //Is player?
        if (raycast.Length > 0)
            foreach (var ray in raycast)
            {
                if (ray.collider.CompareTag("Player"))
                    return true;
            }
        return false;
    }

    [SerializeField] protected float groundCheckX = 0f;
    [SerializeField] protected float groundCheckY = 0f;
    public bool DetectPlayerInArea()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(new Vector3(transform.position.x,
            transform.position.y), new Vector2(groundCheckX, groundCheckY), 0, ~LayerMask.GetMask("OneWayPlatform", "Ignore Raycast"));
        return col.Length > 0;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x,
            transform.position.y), new Vector2(groundCheckX, groundCheckY));
    }
}
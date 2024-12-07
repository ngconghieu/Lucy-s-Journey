using UnityEngine;

public class CheckTerrain : GameMonoBehaviour
{
    [Header("Check ground & wall")]
    [SerializeField] protected float groundCheckY = 0.5f;
    [SerializeField] protected float groundCheckX = 0.5f;
    [SerializeField] protected LayerMask ground;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLayerMask();
    }

    //protected virtual void Update()
    //{
    //    Debug.DrawRay(transform.position, Vector2.down * groundCheckY, Color.red);
    //    Debug.DrawRay(transform.position, new Vector2(1 * InputManager.Instance.Move(), 0) * groundCheckX, Color.red);
    //    this.CheckGround();
    //    this.CheckWall();
    //}

    private void LoadLayerMask()
    {
        ground = LayerMask.GetMask("Ground");
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckY, ground);
        //Collider2D[] test = Physics2D.OverlapCircleAll(transform.position, 0.2f, ground);
        //return test.Length != 0;
    }

    public bool IsWall()
    {
        return Physics2D.Raycast(transform.position, new Vector2(1 * InputManager.Instance.Move(), 0), groundCheckX, ground);
    }

}

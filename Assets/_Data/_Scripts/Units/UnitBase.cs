using UnityEngine;

public class UnitBase : BaseMonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected Collider2D colliderReceivesDmg;
    [SerializeField] protected Rigidbody2D rb;

    public Animator Anim => anim;
    public Collider2D Collider => colliderReceivesDmg;
    public Rigidbody2D Rigibody => rb;

    protected override void LoadComponent()
    {
        ComponentLoader.LoadComponentInChildren(ref anim, this);
        ComponentLoader.LoadComponent(ref colliderReceivesDmg, this);
        ComponentLoader.LoadComponent(ref rb, this);
    }
}
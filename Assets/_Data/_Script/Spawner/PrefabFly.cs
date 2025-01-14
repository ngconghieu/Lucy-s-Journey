using UnityEngine;

public class PrefabFly : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    private void Update()
    {
        transform.parent.Translate(Vector2.right * moveSpeed);
    }
}

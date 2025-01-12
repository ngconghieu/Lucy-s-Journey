using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dropForce = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ItemEvent.ItemCollected(gameObject);
            Destroy(gameObject);
        }
    }

}

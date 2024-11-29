using UnityEngine;

public class Test : MonoBehaviour
{
    //Rigidbody2D rb;
    //Collider2D cld;
    //protected void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    cld = GetComponent<Collider2D>();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
    }
}

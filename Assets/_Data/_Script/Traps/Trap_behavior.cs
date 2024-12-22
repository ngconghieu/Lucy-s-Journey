using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap_behavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            //collision.gameObject.GetComponent<DmgReceiver>().Deduct(damage);
            SceneManager.LoadScene("Main Scene");
        }
    }
}


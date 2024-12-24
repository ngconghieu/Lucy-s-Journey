using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap_behavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private int damage = 1;
    private float damageInterval = 1f; // Thời gian giữa các lần gây sát thương
    private float timeSinceLastDamage = 0f; // Thời gian đã trôi qua kể từ lần gây sát thương cuối

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            

            if (timeSinceLastDamage >= damageInterval)
            {
                // Gây sát thương cho người chơi
                collision.gameObject.GetComponent<DmgReceiver>().Deduct(damage);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                timeSinceLastDamage = 0f; // Đặt lại thời gian đã trôi qua
            }
            timeSinceLastDamage += Time.deltaTime; // Cập nhật thời gian đã trôi qua
        }
    }
}
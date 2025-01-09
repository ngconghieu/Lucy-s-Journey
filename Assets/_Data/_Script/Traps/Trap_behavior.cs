using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    [SerializeField] public int damage = 2; // Sát thương gây ra
    [SerializeField] private float damageInterval = 1f; // Thời gian giữa các lần gây sát thương
    private float timeSinceLastDamage = 0f; // Thời gian đã trôi qua từ lần gây sát thương cuối
    private GameObject player; // Tham chiếu đến đối tượng người chơi

    private void Update()
    {
        // Nếu player đã vào bẫy, kiểm tra thời gian
        if (player != null)
        {
            timeSinceLastDamage += Time.deltaTime; // Tăng thời gian đã trôi qua

            // Nếu đã đến thời điểm gây sát thương
            if (timeSinceLastDamage >= damageInterval)
            {
                // Gây sát thương
                DealDamage();
                timeSinceLastDamage = 0f; // Đặt lại thời gian
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject; // Lưu tham chiếu đến người chơi
            Debug.Log("Player entered trap.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null; // Đặt lại tham chiếu khi người chơi ra khỏi bẫy
            timeSinceLastDamage = 0f; // Đặt lại thời gian
            Debug.Log("Player exited trap.");
        }
    }

    private void DealDamage()
    {
        // Lấy thành phần DmgReceiver từ đối tượng con của Player_0
        DmgReceiver dmgReceiver = player.GetComponentInChildren<DmgReceiver>();

        if (dmgReceiver != null)
        {
            // Gây sát thương
            dmgReceiver.Deduct(damage);
            Debug.Log($"Damage dealt: {damage} to the player.");
        }
        else
        {
            Debug.LogError("DmgReceiver component is missing on the player!");
        }
    }
}
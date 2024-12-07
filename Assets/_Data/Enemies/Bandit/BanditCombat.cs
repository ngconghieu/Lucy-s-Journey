using System;
using UnityEngine;

public class BanditCombat : GameMonoBehaviour
{
    [SerializeField] protected bool detectPlayer;
    float dir;
    Vector2 posTarget;
    [SerializeField] float dis = 5f;

    protected virtual void Update()
    {
        //DetectPlayer();
        SweepRaycasts(transform.parent.position, 10f,45, 10, LayerMask.GetMask("Player"));
    }

    private void DetectPlayer()
    {
        dir = transform.parent.localScale.x;
        posTarget = new Vector2(dir * dis + transform.position.x, transform.position.y);
        detectPlayer = Physics2D.Raycast(transform.parent.position,
            new Vector2(dir, 0), transform.parent.position.x + dis, LayerMask.GetMask("Player"));
        //detectPlayer = Physics2D.Linecast(transform.parent.position, posTarget, LayerMask.GetMask("Player"));
    }

    private void SweepRaycasts(Vector2 origin, float range, float angle, int numRays, LayerMask targetLayer)
    {
        float startAngle = -angle / 2; // Góc bắt đầu (âm)
        float angleStep = angle / (numRays - 1); // Bước giữa các tia

        for (int i = 0; i < numRays; i++)
        {
            // Tính góc và hướng của từng ray
            float currentAngle = startAngle + angleStep * i;
            Vector2 direction = Quaternion.Euler(0, 0, currentAngle) * Vector2.right;

            // Bắn raycast
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, range, targetLayer);

            // Debug ray trong Scene View
            Debug.DrawRay(origin, direction * range, hit.collider ? Color.red : Color.green);

            // Xử lý khi raycast chạm vào Player
            if (hit.collider && hit.collider.CompareTag("Player"))
            {
                Debug.Log("Detected Player at angle: " + currentAngle);
                // Kích hoạt hành động (ví dụ: tấn công)
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.parent.position, posTarget);
    }
}

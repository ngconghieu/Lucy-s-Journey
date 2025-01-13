using System.Collections;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [Header("Moving horizontal")]
    [SerializeField] protected float movingSpeed = 7f;

    AudioManager audioManager;
    private Coroutine walkSound;

    protected virtual void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    protected virtual void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        if (playerCtrl.Dashing) return;
        float move = InputManager.Instance.Move();
        playerCtrl.Moving = move;

        if (move != 0)
        {
            if (walkSound == null) // Nếu không có Coroutine nào đang chạy
            {
                walkSound = StartCoroutine(PlayWalkingSound()); // Bắt đầu phát âm thanh
            }
        }
        else
        {
            if (walkSound != null) // Nếu có Coroutine đang phát âm thanh
            {
                StopCoroutine(walkSound); // Dừng Coroutine
                walkSound = null; // Đặt lại trạng thái
                audioManager.StopSFX(); // Dừng âm thanh
            }
        }

        //Moving
        playerCtrl.Rigidbody2D.linearVelocityX = movingSpeed * move;
        //Flip
        if (move < 0) transform.parent.localScale = new Vector3(-1f, 1, 1);
        if (move > 0) transform.parent.localScale = new Vector3(1f, 1, 1);
    }

    private IEnumerator PlayWalkingSound()
    {
        while (true) // Vòng lặp liên tục
        {
            audioManager.PlaySFX(audioManager.walk); // Phát âm thanh
            yield return new WaitForSeconds(audioManager.walk.length); // Chờ thời gian của âm thanh
        }
    }
}
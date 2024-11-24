using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerAbstract
{
    [Header("Moving horizontal")]
    [SerializeField] protected float movingSpeed = 9f;

    protected virtual void Update()
    {
        if (playerCtrl.dashing) return;
        this.Moving();
    }

    protected virtual void Moving()
    {
        float xAxis = InputManager.Instance.XAxis;
        //Moving
        playerCtrl.Rigidbody2D.linearVelocityX = movingSpeed * xAxis;
        //Flip
        //if (xAxis < 0) transform.parent.localScale = new Vector3(-4f, 4, 1);
        //if (xAxis > 0) transform.parent.localScale = new Vector3(4f, 4, 1);
        if (xAxis < 0) transform.parent.localScale = new Vector3(-1f, 1, 1);
        if (xAxis > 0) transform.parent.localScale = new Vector3(1f, 1, 1);
    }

}

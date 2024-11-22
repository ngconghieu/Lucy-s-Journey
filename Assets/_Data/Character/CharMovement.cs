using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMovement : GameMonoBehaviour
{
    [SerializeField] protected float speed = 7f;
    [SerializeField] Rigidbody2D _rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody2D != null) return;
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.CharMoving();
    }

    protected virtual void CharMoving()
    {
        Vector2 movementInput = InputManager.Instance.MovementInput;
        Vector2 pos = _rigidbody2D.position;
        if (movementInput.x < 0)
        {
            //A Holding
            transform.parent.localScale = new Vector3(-4f, 4f, 1f);
        }
        if (movementInput.x > 0)
        {
            //D Holding
            transform.parent.localScale = new Vector3(4f, 4f, 1f);
        }
        if (movementInput.y > 0)
        {
            //W Holding
        }
        if (movementInput.y < 0)
        {
            //S Holding
        }

        Vector2 targetPosition = new(pos.x + speed * Time.fixedDeltaTime * movementInput.x, pos.y);
        _rigidbody2D.MovePosition(Vector2.MoveTowards(pos, targetPosition, 0.5f));



    }

}

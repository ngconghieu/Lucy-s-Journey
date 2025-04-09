using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] private float _runHorizontal;
    public float RunHorizontal => _runHorizontal;

    public event Action OnJumpEvent;
    public event Action OnDashEvent;
    public event Action OnAttackEvent;

    public void OnRun(InputAction.CallbackContext context)
    {
        _runHorizontal = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnDashEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAttackEvent?.Invoke();
        }
    }
}

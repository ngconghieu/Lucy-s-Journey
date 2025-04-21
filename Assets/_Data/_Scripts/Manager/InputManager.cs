using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : Singleton<InputManager>
{
    [SerializeField] private float _runHorizontal;
    [SerializeField] private PlayerInput _playerInput;

    private Dictionary<string, Action<InputAction.CallbackContext>> _inputActions;

    public float RunHorizontal => _runHorizontal;
    public event Action OnDash;
    public event Action OnJump;

    protected override void Awake()
    {
        base.Awake();
        LoadPlayerInput();
        _inputActions = new();

        RegisterActionHandlers();
        BindInputActions();
    }

    private void LoadPlayerInput()
    {
        if (_playerInput != null) return;
        _playerInput = GetComponent<PlayerInput>();
        Debug.Log("LoadPlayerInput", gameObject);
    }

    private void RegisterActionHandlers()
    {
        _inputActions.Add(Const.Run, HandleMove);
        _inputActions.Add(Const.Dash, HandleDash);
        _inputActions.Add(Const.Jump, HandleJump);
    }

    private void BindInputActions()
    {
        foreach (var action in _playerInput.actions)
        {
            if (_inputActions.ContainsKey(action.name))
            {
                action.started += _inputActions[action.name];
                action.performed += _inputActions[action.name];
                action.canceled += _inputActions[action.name];
            }
            else
            {
                //Debug.LogWarning($"No handler registered for action: {action.name}");
            }
        }
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        _runHorizontal = context.ReadValue<Vector2>().x;
    }

    private void HandleDash(InputAction.CallbackContext context)
    {
        if (context.started)
            OnDash?.Invoke();
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
            OnJump?.Invoke();
    }
}

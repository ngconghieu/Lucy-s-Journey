using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : BaseMonoBehaviour, IInputProvider
{
    [SerializeField] private PlayerInput _playerInput;

    private Dictionary<string, Action<InputAction.CallbackContext>> _inputActions;

    public float MoveInput { get; private set; }

    public event Action OnDash;
    public event Action OnJump;

    protected override void Awake()
    {
        base.Awake();
        ComponentLoader.LoadComponent(ref _playerInput, this);
        _inputActions = new();

        RegisterActionHandlers();
        BindInputActions();
        ServiceLocator.Register<IInputProvider>(this);

    }

    private void OnDestroy()
    {
        UnbindInputActions();
        ServiceLocator.Register<IInputProvider>(null);
    }

    private void RegisterActionHandlers()
    {
        _inputActions[Const.Run] = HandleMove;
        _inputActions[Const.Dash] = HandleDash;
        _inputActions[Const.Jump] = HandleJump;
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
                //Debug.LogWarning($"No handler registered for action: {action.name}", gameObject);
            }
        }
    }

    private void UnbindInputActions()
    {
        foreach (var action in _playerInput.actions)
        {
            if (_inputActions.ContainsKey(action.name))
            {
                action.started -= _inputActions[action.name];
                action.performed -= _inputActions[action.name];
                action.canceled -= _inputActions[action.name];
            }
        }
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>().x;
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

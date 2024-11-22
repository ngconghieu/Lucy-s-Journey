using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos => mouseWorldPos;

    protected InputSystem_Actions inputActions;

    protected Vector2 movementInput;
    public Vector2 MovementInput => movementInput;

    protected virtual void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("InputManager already exists");
        instance = this;
        inputActions = new InputSystem_Actions();
    }

    protected virtual void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    protected virtual void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Disable();
    }

    protected void FixedUpdate()
    {
        GetMousePos();
    }

    private void GetMousePos()
    {
        //get mousePoint from screen to world point
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void GetMouseDown()
    {
        //TO DO
    }

    protected virtual void OnMove(InputAction.CallbackContext context)
    {
        this.movementInput = context.ReadValue<Vector2>();
    }
}

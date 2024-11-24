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

    [SerializeField] protected float xAxis;
    public float XAxis => xAxis;
    protected virtual void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("InputManager already exists");
        instance = this;
    }


    protected void FixedUpdate()
    {
        GetMousePos();
        this.Moving();
    }

    private void Moving()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    private void GetMousePos()
    {
        //get mousePoint from screen to world point
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}

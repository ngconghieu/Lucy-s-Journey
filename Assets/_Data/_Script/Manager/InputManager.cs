using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    protected virtual void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("InputManager already exists");
        instance = this;
    }

    public float Move() => Input.GetAxisRaw("Horizontal");
    public bool Dash() => Input.GetButtonDown("Dash");
    public bool Jump() => Input.GetButtonDown("Jump");
    public bool Attack() => Input.GetButtonDown("Fire1");
}
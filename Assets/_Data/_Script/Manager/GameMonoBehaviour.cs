using UnityEngine;

public abstract class GameMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.ResetValue();
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void OnEnable()
    {
        //For override
    }

    protected virtual void OnDisable()
    {
        //For override
    }

    protected virtual void ResetValue()
    {
        //For override
    }
}
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour
{
    protected virtual void LoadComponent()
    {
        // For override
    }
    protected virtual void ResetValue()
    {
        // For override
    }

    protected virtual void Awake()
    {
        LoadComponent();
    }

    protected virtual void Reset()
    {
        ResetValue();
        LoadComponent();
    }

}

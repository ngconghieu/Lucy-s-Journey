using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        // For override
    }
    protected virtual void SetValue()
    {
        // For override
    }

    protected virtual void Reset()
    {
        SetValue();
        Awake();
    }

}

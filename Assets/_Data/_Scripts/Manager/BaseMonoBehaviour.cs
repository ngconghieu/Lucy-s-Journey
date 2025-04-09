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

    protected void LoadComponent<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponent<T>();
        DebugLoadComponent(typeof(T).Name);
    }

    protected void LoadComponentInChildren<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponentInChildren<T>(true);
        DebugLoadComponent(typeof(T).Name);
    }

    protected void LoadComponentInParent<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponentInParent<T>();
        DebugLoadComponent(typeof(T).Name);
    }

    protected virtual void DebugLoadComponent(string nameComponent)
    {
        Debug.Log($"Load{nameComponent}", gameObject);
    }
}

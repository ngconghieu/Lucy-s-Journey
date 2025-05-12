using UnityEngine;

public static class ComponentLoader
{
    public static void LoadComponent<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponent<T>();
        DebugLoadComponent(typeof(T).Name, obj);
    }

    public static void LoadComponentInChildren<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponentInChildren<T>(true);
        DebugLoadComponent(typeof(T).Name, obj);
    }

    public static void LoadComponentInParent<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponentInParent<T>();
        DebugLoadComponent(typeof(T).Name, obj);
    }

    public static void DebugLoadComponent(string nameComponent, Component obj)
    {
        Debug.Log($"Load{nameComponent}", obj);
    }
}
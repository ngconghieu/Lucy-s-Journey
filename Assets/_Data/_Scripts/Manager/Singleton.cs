using UnityEngine;

public class Singleton<T> : BaseMonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Instance => _instance;

    protected override void Awake()
    {
        LoadInstance();
        base.Awake();
    }

    private void LoadInstance()
    {
        if(_instance != null)
        {
            Debug.LogError($"Instance of {typeof(T).Name} already exists. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }
        _instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
}

using UnityEngine;
using System;

public class ItemEvent:MonoBehaviour
{
    public static event Action<GameObject> OnItemCollected;

    public static void ItemCollected(GameObject item)
    {
        OnItemCollected?.Invoke(item);
    }
}

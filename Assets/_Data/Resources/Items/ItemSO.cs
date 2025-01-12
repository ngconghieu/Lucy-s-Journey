using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class ItemSO : ScriptableObject
{
    public GameObject prefab;
    public string itemCode;
    public string itemName;
}
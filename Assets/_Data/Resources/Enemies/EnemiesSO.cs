using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemies", menuName = "Scriptable Objects/Enemies")]
public class EnemiesSO : BaseStatsSO
{
    public float moveSpeed = 7f;
    public List<DropItem> dropList;
}
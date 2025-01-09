using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class PlayerSO : BaseStatsSO
{
    private void OnEnable()
    {
        this.name = "Player";
        this.hpMax = 20;
        this.dmg = 3;
    }
}
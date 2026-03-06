using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : BaseStats
{
    public float JumpForce = 20f;
    public float MaxHealth = 10f;
    // Example of how to use the stats in a method
    private void Reset()
    {
        Speed = 7f;
    }
}
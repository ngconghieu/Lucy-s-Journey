using UnityEngine;

public class PlayerState
{
    public float Moving { get; set; }
    public  bool Jumping { get; set; }
    public bool DoubleJump { get; set; }
    public bool Dashing { get; set; }
    public bool IsGrounded { get; set; }
    public bool IsWall { get; set; }
    public bool NormalAttack1 { get; set; }
    public bool NormalAttack2 { get; set; }
    public bool NormalAttack3 { get; set; }
}

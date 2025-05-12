using System;

public interface IInputProvider
{
    float RunHorizontal { get; }
    event Action OnDash;
    event Action OnJump;
}
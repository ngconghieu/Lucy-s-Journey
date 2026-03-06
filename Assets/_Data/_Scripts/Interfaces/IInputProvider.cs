using System;
using UnityEngine;

public interface IInputProvider
{
    float MoveInput { get; }
    event Action OnDash;
    event Action OnJump;
}
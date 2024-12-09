using UnityEngine;

public class BanditBase : GameMonoBehaviour
{
    protected StateMachine stateMachine;
    protected override void Awake()
    {
        stateMachine = new StateMachine();
    }

    protected virtual void Update()
    {
        stateMachine.Update();
    }
}

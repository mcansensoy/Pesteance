using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2NormalState : W2State
{
    public W2NormalState(Lance _lance, W2StateMachine _stateMachine, string _animBoolName) : base(_lance, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Mouse1)){
            w2StateMachine.ChangeState(lance.w2attackState);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            w2StateMachine.ChangeState(lance.w2skill);
        }
    }
}

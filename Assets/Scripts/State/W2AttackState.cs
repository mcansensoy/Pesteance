using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2AttackState : W2State
{
    public W2AttackState(Lance _lance, W2StateMachine _stateMachine, string _animBoolName) : base(_lance, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        lance.LanceCollider.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        lance.LanceCollider.gameObject.SetActive(false);
    }

    public override void Update()
    {
        base.Update();

        if(triggerCalled){
            w2StateMachine.ChangeState(lance.w2normalState);
        }
    }
}

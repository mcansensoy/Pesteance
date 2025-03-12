using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2StateMachine
{
    public W2State w2CurrentState { get; private set; }
    
    public void Initialize(W2State _startState){
        w2CurrentState = _startState;
        w2CurrentState.Enter();
    }

    public void ChangeState(W2State _newState){
        w2CurrentState.Exit();
        w2CurrentState = _newState;
        w2CurrentState.Enter();
    }
}

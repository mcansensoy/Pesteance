using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine: Singleton<PlayerStateMachine>
{
    public PlayerState currentState { get; private set; }

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }



    public void Initialize(PlayerState _startState){
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState){
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}

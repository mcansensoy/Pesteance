using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2State
{
    protected W2StateMachine w2StateMachine;
    protected Lance lance;
    protected Player player;
    protected Rigidbody2D rb;
    protected float stateTimer;
    
    private string animBoolName;
    protected bool triggerCalled;

    public W2State(Lance _lance, W2StateMachine _stateMachine, string _animBoolName){
        this.lance = _lance;
        this.w2StateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter(){
        lance.lanceAnimator.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Update(){
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit(){
        lance.lanceAnimator.SetBool(animBoolName, false);
    }
    public virtual void Animation2FinishTrigger(){
        triggerCalled = true;
    }
}

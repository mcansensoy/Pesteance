using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState
{
    protected WeaponStateMachine weaponStateMachine;
    //public Skill skill;
    protected Sword sword;
    protected Player player;
    protected Rigidbody2D rb;
    protected float stateTimer;
    

    //protected Sword_Skill throwSkill;
    
    private string animBoolName;
    protected bool triggerCalled;

    public WeaponState(Sword _sword, WeaponStateMachine _stateMachine, string _animBoolName){
        this.sword = _sword;
        this.weaponStateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter(){
        sword.myAnimator.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Update(){
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit(){
        sword.myAnimator.SetBool(animBoolName, false);
    }
    public virtual void AnimationFinishTrigger(){
        triggerCalled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : WeaponState
{
    public EmptyState(Sword _sword, WeaponStateMachine _stateMachine, string _animBoolName) : base(_sword, _stateMachine, _animBoolName)
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

        if(Input.GetKeyDown(KeyCode.Q)){
            Sword_Skill_Controller newSwordScript = sword.newSword.GetComponent<Sword_Skill_Controller>();
            newSwordScript.SetupSword(player);
            newSwordScript.ReturnSword();
        }
    }
}

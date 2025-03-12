using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSwordState : WeaponState
{
    public AimSwordState(Sword _sword, WeaponStateMachine _stateMachine, string _animBoolName) : base(_sword, _stateMachine, _animBoolName)
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

        if(Input.GetKeyUp(KeyCode.Q)){
            weaponStateMachine.ChangeState(sword.empty);
            //throwSkill.CreateSword();
        }
    }
}

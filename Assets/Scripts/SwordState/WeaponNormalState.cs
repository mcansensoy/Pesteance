using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNormalState : WeaponState
{
    public WeaponNormalState(Sword _sword, WeaponStateMachine _stateMachine, string _animBoolName) : base(_sword, _stateMachine, _animBoolName)
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

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            weaponStateMachine.ChangeState(sword.attackState);
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            weaponStateMachine.ChangeState(sword.aimSword);
        }
    }
}

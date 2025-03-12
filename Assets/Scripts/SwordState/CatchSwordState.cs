using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchSwordState : WeaponState
{
    public CatchSwordState(Sword _sword, WeaponStateMachine _stateMachine, string _animBoolName) : base(_sword, _stateMachine, _animBoolName)
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

        weaponStateMachine.ChangeState(sword.normalState);
    }
}

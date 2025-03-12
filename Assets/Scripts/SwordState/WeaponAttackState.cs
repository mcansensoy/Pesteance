using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackState : WeaponState
{
    public WeaponAttackState(Sword _sword, WeaponStateMachine _stateMachine, string _animBoolName) : base(_sword, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        sword.weaponCollider.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        sword.weaponCollider.gameObject.SetActive(false);
    }

    public override void Update()
    {
        base.Update();

        if(triggerCalled){
            weaponStateMachine.ChangeState(sword.normalState);
        }
    }
}

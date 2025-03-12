using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine
{
    public WeaponState weaponCurrentState { get; private set; }
    
    public void Initialize(WeaponState _startState){
        weaponCurrentState = _startState;
        weaponCurrentState.Enter();
    }

    public void ChangeState(WeaponState _newState){
        weaponCurrentState.Exit();
        weaponCurrentState = _newState;
        weaponCurrentState.Enter();
    }
}

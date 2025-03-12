using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    //public MonoBehaviour Current_ActiveWeapon { get; private set; }


    /*private PlayerControls _playerControls_s;
    private bool attackButton_down, isAttacking = false;
    private float attack_cooldown;



    protected override void Awake()
    {
        base.Awake();
        _playerControls_s = new PlayerControls();
    }


    private void OnEnable()
    {
        _playerControls_s.Enable();
    }

    private void Start()
    {
        _playerControls_s.Combat.Attack.started += _ => Start_Attacking();
        _playerControls_s.Combat.Attack.canceled += _ => Stop_Attacking();


        Attack_Cooldown();
    }


    private void Update()
    {
        Attack_s();
    }







    public void New_Weapon(MonoBehaviour newWeapon_aw)
    {
        Current_ActiveWeapon = newWeapon_aw;

        Attack_Cooldown();

        attack_cooldown = (Current_ActiveWeapon as IWeapon).Get_WeaponInfo().weaponCooldown;
    }

    public void Weapon_Null()
    {
        Current_ActiveWeapon = null;
    }










    private void Start_Attacking()
    {
        attackButton_down = true;
    }

    private void Stop_Attacking()
    {
        attackButton_down = false;
    }





    private void Attack_s()
    {
        if(attackButton_down && !isAttacking && Current_ActiveWeapon)
        {
            Attack_Cooldown();
            
            (Current_ActiveWeapon as IWeapon).Attack_s();
        }
    }
   
    
    
    
    
    
    
    
    private void Attack_Cooldown()
    {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(Time_between_Attack_Routine());
    }


    private IEnumerator Time_between_Attack_Routine()
    {
        yield return new WaitForSeconds(attack_cooldown);
        isAttacking = false;
    }*/
}


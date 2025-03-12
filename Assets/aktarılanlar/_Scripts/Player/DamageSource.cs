using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] public int Damage_amount;

    private void Start()
    {
        //MonoBehaviour currentActive_weapon = ActiveWeapon.Instance_T.Current_ActiveWeapon;
        //Damage_amount = (currentActive_weapon as IWeapon).Get_WeaponInfo().weaponDamage;
    }



    private void OnTriggerEnter2D(Collider2D ds)
    {
        EnemyHealth enemyHealth_ds = ds.gameObject.GetComponent<EnemyHealth>();
        enemyHealth_ds?.Take_Damage(Damage_amount);
    }
}

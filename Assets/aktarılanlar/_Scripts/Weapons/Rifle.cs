using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo_;
    [SerializeField] private GameObject bullet_Prefab;
    [SerializeField] private Transform bullet_SpawnPoint;

    private Animator SMG_Animator;
    readonly int FIRE_HASH = Animator.StringToHash("Fire");


    private void Awake()
    {
        SMG_Animator = GetComponent<Animator>();
    }

    public void Attack_s()
    {
        SMG_Animator.SetTrigger(FIRE_HASH);

        GameObject new_Bullet = 
           // Instantiate(arrow_Prefab, arrow_SpawnPoint.position, ActiveWeapon.Instance_T.transform.rotation);
            Instantiate(bullet_Prefab, bullet_SpawnPoint.position, transform.rotation);

        //new_Arrow.GetComponent<Projectile>().Update_Weapon_Info(weaponInfo_);
        new_Bullet.GetComponent<Projectile>().Update_ProjectileRange(weaponInfo_.weaponRange);

    }


    public WeaponInfo Get_WeaponInfo()
    {
        return weaponInfo_;
    }
}

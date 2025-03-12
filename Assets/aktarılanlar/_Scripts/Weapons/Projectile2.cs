using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    [SerializeField] private float bullet_Speed;
    [SerializeField] private GameObject particle_Hit_VFX;
    [SerializeField] private bool isEnemy_projectile;
    [SerializeField] private float projectile_Range_;

    //private WeaponInfo weaponInfo_pr;
    private Vector3 start_Pos;


    private void Start()
    {
        start_Pos = transform.position;
    }

    void Update()
    {
        Move_Projectile();
        Detect_FireDistance();
    }










    //public void Update_Weapon_Info(WeaponInfo w_i)
    public void Update_ProjectileRange(float projectile_R)
    {
        //this.weaponInfo_pr = w_i;
        this.projectile_Range_ = projectile_R;
    }

    public void Update_Bullet_speed(float bullet_sp)
    {
        this.bullet_Speed = bullet_sp;
    }


    private void OnCollisionEnter2D(Collision2D cd)
    {
        if (cd.collider.tag!="Player")
        {
            Instantiate(particle_Hit_VFX, transform.position, transform.rotation);
            Destroy(gameObject, .1f);
        }
        else if(cd.collider.tag == "Player")
        {
            Instantiate(particle_Hit_VFX, transform.position, transform.rotation);
            Destroy(gameObject, .2f);
        }
    }





    private void OnTriggerEnter2D(Collider2D c)
    {
        EnemyHealth enemyHealth_pr = c.gameObject.GetComponent<EnemyHealth>();

        PlayerHealth player_H_proj = c.gameObject.GetComponent<PlayerHealth>();

        if (c.isTrigger && (enemyHealth_pr || player_H_proj))
        {

            if(player_H_proj && isEnemy_projectile)
            {
                if((player_H_proj && isEnemy_projectile || (enemyHealth_pr || !isEnemy_projectile)))
                {
                    player_H_proj?.Player_Take_Damage(5, transform);
                    Instantiate(particle_Hit_VFX, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                else if (c.isTrigger)
                {
                    Instantiate(particle_Hit_VFX, transform.position, transform.rotation);
                    Destroy(gameObject);                    
                }
            }
        }
    }











    private void Move_Projectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * bullet_Speed);
    }




    private void Detect_FireDistance()
    {
        //if (Vector3.Distance(transform.position, start_Pos) > weaponInfo_pr.weaponRange)
        //{
        //    Destroy(gameObject);
        //}


        if (Vector3.Distance(transform.position, start_Pos) > projectile_Range_)
        {
            Destroy(gameObject);
        }
    }


}

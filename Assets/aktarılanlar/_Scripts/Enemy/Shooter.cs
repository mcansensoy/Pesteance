using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletRange;
    [SerializeField] private int burstCount;
    [Header("")]
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;

    [Header("Burst")]
    [SerializeField] [Range(0, 359)] private float angleSpread;
    [SerializeField] private float startingDistance = 0.1f;
    [SerializeField] private int projectiles_perBurst;

    [Header("Oscillate")]
    [SerializeField] private bool oscillate;
    [SerializeField] private bool stagger;



    private bool isShooting = false;


    private void OnValidate()
    {
        if(oscillate) { stagger = true; }
        if(!oscillate) { stagger = false; }
        if (projectiles_perBurst < 1) { projectiles_perBurst = 1; }
        if (burstCount < 1) { burstCount = 1; }
        if (timeBetweenBursts < 0.1f) { timeBetweenBursts = 0.1f; }
        if (restTime < 0.1f) { restTime = 0.1f; }
        if(startingDistance < 0.1f) { startingDistance = 0.1f; }
        if (angleSpread == 0) { projectiles_perBurst = 1; }
        if (bulletRange <= 0) { bulletRange = 2f; }
    }







    public void Attack_enemy()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootRoutine());
        }
    }








    private IEnumerator ShootRoutine()
    {
        isShooting = true;

        float start_angle, current_angle, angle_Step, end_Angle;
        float timeBetween_Projectiles = 0f;


        if(stagger) { timeBetween_Projectiles = timeBetweenBursts / projectiles_perBurst; }
        
        Target_Cone_ofInfluence(out start_angle, out current_angle, out angle_Step, out end_Angle);



        for (int i = 0; i < burstCount; i++)
        {

            if (!oscillate)
            {
                Target_Cone_ofInfluence(out start_angle, out current_angle, out angle_Step, out end_Angle);
            }

            if(oscillate && i % 2 != 1)
            {
                Target_Cone_ofInfluence(out start_angle, out current_angle, out angle_Step, out end_Angle);                
            }

            else if(oscillate)
            {
                current_angle = end_Angle;
                end_Angle = start_angle;
                start_angle = current_angle;
                angle_Step *= -1;
            }




            for (int j = 0; j < projectiles_perBurst; j++)
            {
                Vector2 pos_b = Find_Bullet_SpawnPos(current_angle);

                GameObject newBullet = Instantiate(bulletPrefab, pos_b, Quaternion.identity);
                newBullet.transform.right = newBullet.transform.position - transform.position;

                if (newBullet.TryGetComponent(out Projectile projectile_sh))
                {
                    projectile_sh.Update_ProjectileRange(bulletRange);
                }

                current_angle += angle_Step;

                if(stagger) { yield return new WaitForSeconds(timeBetween_Projectiles); }

            }

            current_angle = start_angle;

            if (!stagger) { yield return new WaitForSeconds(timeBetweenBursts); }            
        
        }

        yield return new WaitForSeconds(restTime);
        isShooting = false;
    }









    private void Target_Cone_ofInfluence(out float start_angle, out float current_angle, out float angle_Step, out float end_Angle)
    {
        Vector2 target_dir = Player.Instance_T.transform.position - transform.position;
        float target_Angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

        start_angle = target_Angle;
        current_angle = target_Angle;
        end_Angle = target_Angle;
        float half_angleSpread = 0f;
        angle_Step = 0;


        if (angleSpread != 0)
        {
            angle_Step = angleSpread / (projectiles_perBurst - 1);
            half_angleSpread = angleSpread / 2f;
            start_angle = target_Angle - half_angleSpread;
            current_angle = start_angle;
            end_Angle = target_Angle + half_angleSpread;
        }
    }








    private Vector2 Find_Bullet_SpawnPos(float cur_angle)
    {

        float x = transform.position.x + startingDistance * Mathf.Cos(cur_angle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(cur_angle * Mathf.Deg2Rad);

        Vector2 pos_ = new(x, y);

        return pos_;
    }

}
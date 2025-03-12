using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class EnemyLaser : MonoBehaviour
{
    public GameObject laserPrefab;
    public float shootInterval = 3f;
    public float laserSpeed = 10f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ShootLaser());
    }

    private IEnumerator ShootLaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            if (player != null)
            {
                // Calculate the direction from the enemy to the player
                Vector2 direction = (player.position - transform.position).normalized;

                // Instantiate the laser prefab at the enemy's position
                GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

                // Calculate the velocity based on the direction and laser speed
                Vector2 laserVelocity = direction * laserSpeed;

                // Get the laser's rigidbody and set its velocity
                Rigidbody2D laserRb = laser.GetComponent<Rigidbody2D>();
                if (laserRb)
                {
                    laserRb.velocity = laserVelocity;
                }

                // Destroy the laser after some time (you can adjust this value to control the laser's lifetime)
                //Destroy(laser, 2f);
            }
        }
    }
}

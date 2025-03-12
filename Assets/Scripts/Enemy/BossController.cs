using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private int i = 0;
    public int maxHealth = 5;
    public int attackDamage = 20;
    public GameObject enemyToSpawn;
    public GameObject enemyToSpawn2;
    public GameObject bulletPrefab;
    public float attackCooldown = 2.0f;
    public float spawnCooldown = 5.0f;
    public float bulletSpeed = 5.0f;
    public Transform firePoint; // The position from where bullets are shot

    private int currentHealth;
    private Transform player;
    private bool isAttacking;
    private bool canSpawn;

    private Knockback knockback;
    private Flash flash;

    private RandomMovement randomMovement;
    
    

    

    private void Awake() {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        randomMovement = GetComponent<RandomMovement>();
        
    }

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isAttacking = false;
        canSpawn = true;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            StartCoroutine(Attack());
        }

        if (canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        // Play attack animation here

        // Aim at the player
        
        
        
        

        // Shoot a bullet towards the player
        ShootBullet();

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    private void ShootBullet()
    {
        for (i=0;i<15;i++)
        {
            Vector2 Direction = Random.insideUnitCircle.normalized;;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = Direction * bulletSpeed;
        }
    }
    

    private IEnumerator SpawnEnemy()
    {
        canSpawn = false;
        // Play spawn animation here

        // Spawn the enemy
        Instantiate(enemyToSpawn, transform.position + Vector3.up, Quaternion.identity);

        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }

    public void aTakeDamage(int damage)
    {
        knockback.GetKnockedBack(PlayerController.Instance.transform, 15f);
        StartCoroutine(flash.FlashRoutine());
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        // Play hurt animation or effects here
        for (i = 0; currentHealth+i<6 ;i++)
            Instantiate(enemyToSpawn2, transform.position + Vector3.up, Quaternion.identity);
        
        randomMovement.moveSpeed = randomMovement.moveSpeed + 1;
    }

    private void Die()
    {
        // Play death animation or effects here
        // Handle post-boss behavior (e.g., level completion, rewards, etc.)
        Destroy(gameObject);
    }

    // Handle collision with the player's sword
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            // Assuming the player's sword has a SwordDamage script to handle damage
            
            aTakeDamage(1);
            
            
        }
    }
}
    


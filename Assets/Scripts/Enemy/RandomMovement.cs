using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 3f;   // The speed at which the enemy moves.
    public float changeInterval = 2f;  // The interval at which the enemy changes direction.

    private Rigidbody2D rb;
    private float timer;
    private Vector2 moveDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeInterval;
        GetRandomDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            GetRandomDirection();
            timer = changeInterval;
        }

        Move();
    }

    void Move()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    void GetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad)).normalized;
    }
}

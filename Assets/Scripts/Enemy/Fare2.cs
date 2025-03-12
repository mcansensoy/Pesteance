using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arı : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5.5f;
    private PlayerHealth _playerHealth;

    private void Awake() {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the object to the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Move the object towards the player with a specific speed
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }

    
    
    
}

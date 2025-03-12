using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5.5f;
    private PlayerHealth _playerHealth;
    [SerializeField] GameObject bomber;
    

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

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player" || other.gameObject.tag == "Sword") {
            
            Destroy(bomber,0.4f);
    }
    }
    
    
    
}

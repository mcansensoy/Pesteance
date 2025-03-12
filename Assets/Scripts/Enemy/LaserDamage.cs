using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LaserDamage : MonoBehaviour
{
    private PlayerController playerController;
    // The amount by which to decrease the player's velocity
    public float velocityDecreaseAmount = 4f;
    // The duration of the velocity decrease effect
    public float velocityDecreaseDuration = 2f;

    private bool isVelocityDecreased = false;
    private Vector2 originalVelocity;
    private Rigidbody2D playerRb;

    void Awake(){
        playerController = GetComponent<PlayerController>();
    }

    // Called when a collision occurs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Check if the collision is with an object tagged "Laser"
        if (collision.gameObject.CompareTag("Laser"))
        {
            
            playerRb = GetComponent<Rigidbody2D>();
            if (playerRb != null && !isVelocityDecreased)
            {
                
                originalVelocity = playerRb.velocity;
                StartCoroutine(DecreaseVelocityForDuration());
                Destroy(collision.gameObject,0.1f);
            }
        }
        
    }

    private IEnumerator DecreaseVelocityForDuration()
    {
        isVelocityDecreased = true;

        // Decrease the player's velocity
        Vector2 currentVelocity = playerRb.velocity;
        Vector2 newVelocity = currentVelocity.normalized * Mathf.Max(0, currentVelocity.magnitude - velocityDecreaseAmount);
        playerRb.velocity = newVelocity;
        playerController.moveSpeed -= velocityDecreaseAmount;

        // Wait for the specified duration
        yield return new WaitForSeconds(velocityDecreaseDuration);

        playerController.moveSpeed += velocityDecreaseAmount;

        // Restore the player's original velocity
        playerRb.velocity = originalVelocity;

        isVelocityDecreased = false;

    }
}

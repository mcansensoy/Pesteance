using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_splatter : MonoBehaviour
{
    private SpriteFader spriteFade;

    private void Awake()
    {
        spriteFade = GetComponent<SpriteFader>();
    }

    private void Start()
    {
        StartCoroutine(spriteFade.Fade_Routine());

        Invoke("DisableCollider", 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        playerHealth?.Player_Take_Damage(10, transform);
    }

    private void DisableCollider()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject != GameObject.Find("Player"))
        {
            Destroy(gameObject);
        }
            
    }
}

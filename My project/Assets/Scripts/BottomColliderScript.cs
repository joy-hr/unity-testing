using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomColliderScript : MonoBehaviour
{
    // Reference to the HealthManager script.
    public HealthManager healthManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is a circle.
        if (other.CompareTag("Circle"))
        {
            // Destroy the circle.
            Destroy(other.gameObject);
            
            // Decrease player's health and check for game over using the reference.
            healthManager.LoseHealth();
        }
    }
}

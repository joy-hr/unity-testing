using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxChances = 3; // Maximum chances before game over
    private int currentChances; // Current remaining chances

    public GameObject bottomCollider; // Reference to the bottom collider

    public Image[] healthIcons; // Array of health icons

    private void Start()
    {
        currentChances = maxChances; // Initialize current chances
        Updatehealths(); // Update the healths
    }

    // Method to reduce health (called when a tile hits the bottom)
    public void LoseHealth()
    {
        currentChances--;

        if (currentChances <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
        }

        Updatehealths(); // Update the healths display when health changes
    }

    // Update the displayed healths based on the current health
    private void Updatehealths(){

        int currentHealth = currentChances;

        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                // Display the health
                healthIcons[i].enabled = true;
            }
            else
            {
                // Hide the health
                healthIcons[i].enabled = false;
            }
        }

    }
}

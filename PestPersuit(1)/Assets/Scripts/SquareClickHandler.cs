using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareClickHandler : MonoBehaviour
{
    private int clickCount = 0;
    private bool isDestroyed = false;

    private void Update()
    {
        // Check if the object has not been destroyed.
        if (!isDestroyed)
        {
            // Check for input (e.g., mouse click or touch).
            if (Input.GetMouseButtonDown(0)) // Change 0 to the appropriate button index if needed.
            {
                // Cast a ray from the mouse position to detect collisions.
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // Check if the ray hit this object's collider.
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    // Increment the click count.
                    clickCount++;

                    // Handle the click event based on the click count.
                    switch (clickCount)
                    {
                        case 1:
                            // Handle the first click (e.g., change color).
                            GetComponent<Renderer>().material.color = Color.yellow;
                            break;
                        case 2:
                            GetComponent<Renderer>().material.color = Color.red;
                            break;
                        case 3:
                            // Handle the second click (e.g., destroy the object).
                            Destroy(gameObject);
                            isDestroyed = true; // Mark the object as destroyed.
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

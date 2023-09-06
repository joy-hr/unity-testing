using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClickHandler : MonoBehaviour
{
    private bool isClicked = false;

    private void Update()
    {
        // Check if the object has already been clicked and is not destroyed.
        if (!isClicked && gameObject != null)
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
                    // Handle the click event (e.g., score points, play a sound, etc.).
                    // ...

                    // Mark the object as clicked to avoid further interactions.
                    isClicked = true;

                    // Destroy the object (optional).
                    Destroy(gameObject);
                }
            }
        }
    }
}

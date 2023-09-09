using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTapEnemy : Enemy
{
    [Min(0)]
    public int tapCount = 3;

    int amountTapped = 0;

    private void OnEnable()
    {
        inputManager.OnStartTouch += OnTouch;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= OnTouch;
    }


    public void OnTouch(Vector2 position)
    {
        if (Overlaps(position))
        {

			Debug.Log("Touched");

            transform.localScale *= 0.9f;

            if (++amountTapped >= tapCount)
                Destroy(gameObject);
        }
    }
}

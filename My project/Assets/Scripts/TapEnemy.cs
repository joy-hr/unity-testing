using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapEnemy : Enemy
{
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
		if (Overlaps(position)) {
			Debug.Log("Touched");
			Destroy(gameObject);
		}
	}
}

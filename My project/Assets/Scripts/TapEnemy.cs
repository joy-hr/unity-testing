using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapEnemy : Enemy
{
    [Min(0)]
    public float movementSpeed = 8f;

    private void OnEnable()
    {
        inputManager.OnStartTouch += OnTouch;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= OnTouch;
    }

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
    }

	public void OnTouch(Vector2 position)
	{
		if (Overlaps(position)) {
			Debug.Log("Touched");
			Destroy(gameObject);
		}
	}
}

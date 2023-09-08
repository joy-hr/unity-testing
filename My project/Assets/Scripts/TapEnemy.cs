using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapEnemy : Enemy
{
	[Min(0)]
	public float movementSpeed = 8f; // Changed type to float for smoother movement

	private void OnEnable()
	{
		inputManager.OnStartTouch += OnTouch;
	}

	private void OnDisable() // Unsubscribe from event when object is disabled
	{
		inputManager.OnStartTouch -= OnTouch;
	}

	private void Update()
	{
		enemyObject.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
	}

	private void OnTouch(Vector2 position)
	{
		Vector2 worldCoordinate = Camera.main.ScreenToWorldPoint(position);

		Collider2D hitCollider = Physics2D.OverlapPoint(worldCoordinate, LayerMask.GetMask("Enemy"));

		if (hitCollider != null)
		{
			Destroy(hitCollider.gameObject);
		}
	}
}

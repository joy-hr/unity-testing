using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapEnemy : Enemy
{
	[Min(0)]
	public int movementSpeed = 8;

	void OnEnable()
	{
		inputManager.OnStartTouch += OnTouch;
	}

	void Update()
	{
		enemyObject.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
	}

	void OnTouch(Vector2 position)
	{
		// Convert screen space to world space
		Vector2 worldCoordinate = Camera.main.ScreenToWorldPoint(position);

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			bool overlaps = enemy.GetComponent<Collider2D>().OverlapPoint(worldCoordinate);
			
			if (overlaps) {
				Destroy(enemy);
				break;

			}

		}


	}
}
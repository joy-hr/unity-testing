using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	protected EnemyInputManager inputManager;
	protected GameObject enemyObject;

	void Awake()
	{
		inputManager = EnemyInputManager.Instance;
	}

	protected Action<Vector2> InvokeIfCollided(Action<Vector2> action)
	{
		return position =>
		{
			Vector2 worldCoordinate = Camera.main.ScreenToWorldPoint(position);

			Collider2D hitCollider = Physics2D.OverlapPoint(worldCoordinate, LayerMask.GetMask("Enemy"));

			if (hitCollider != null && gameObject != null && hitCollider.gameObject == gameObject)
				action(position);
		};
	}
}
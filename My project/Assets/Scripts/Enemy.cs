using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	protected EnemyInputManager inputManager;
	protected GameObject enemyObject;

	[Min(0)]
    public float movementSpeed = 8f;

	void Awake()
	{
		inputManager = EnemyInputManager.Instance;
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	private void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
    }

	protected bool Overlaps(Vector2 position)
	{
		Vector2 worldCoordinate = Camera.main.ScreenToWorldPoint(position);
		Collider2D hitCollider = Physics2D.OverlapPoint(worldCoordinate, LayerMask.GetMask("Enemy"));

		return hitCollider != null && gameObject == hitCollider.gameObject;
	}
}
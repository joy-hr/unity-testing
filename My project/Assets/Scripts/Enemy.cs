using UnityEngine;
using UnityEngine.Scripting;

public abstract class Enemy : MonoBehaviour
{
	protected EnemyInputManager inputManager;
	protected GameObject enemyObject;

	void Awake()
	{
		inputManager = EnemyInputManager.Instance;
	}

	void Start()
	{
		enemyObject = gameObject;
	}
}
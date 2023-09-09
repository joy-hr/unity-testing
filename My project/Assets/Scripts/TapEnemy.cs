using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapEnemy : Enemy
{
    [Min(0)]
    public float movementSpeed = 8f;

	Action<Vector2> onTouch;

    private void OnEnable()
    {
		onTouch = OnTouch();
        inputManager.OnStartTouch += onTouch;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= onTouch;
    }

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
    }

	public Action<Vector2> OnTouch()
	{
		return InvokeIfCollided(position =>
        {
            Debug.Log("Touched");
            Destroy(gameObject);
        });
	}
}

using UnityEngine;
using UnityEngine.InputSystem;
using System;

[DefaultExecutionOrder(-1)]
public class EnemyInputManager : MonoBehaviourSingleton<EnemyInputManager>
{
    public event Action<Vector2> OnStartTouch;
    public event Action<Vector2> OnEndTouch;

    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
        touchControls.Touch.Tap.started += StartTouch;
        touchControls.Enable();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(context.ReadValue<Vector2>());
    }
}

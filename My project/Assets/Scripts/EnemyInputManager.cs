using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class EnemyInputManager : MonoBehaviourSingleton<EnemyInputManager>
{
    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position);
    public event EndTouchEvent OnEndTouch;

    TouchControls touchControls;

    void Awake()
    {
        touchControls = new TouchControls();
    }

    void OnEnable()
    {
        touchControls.Enable();
    }

    void OnDisable()
    {
        touchControls.Disable();
    }

    void Start()
    {
        touchControls.Touch.Tap.started += StartTouch;
        touchControls.Touch.Tap.canceled += EndTouch;
    }

    void StartTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
            OnStartTouch(context.ReadValue<Vector2>());
    }

    void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(context.ReadValue<Vector2>());
    }
}

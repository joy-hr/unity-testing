using UnityEngine;

/// <summary>
/// This class provides a Singleton pattern implementation for MonoBehaviour.
/// It ensures that only one instance of a MonoBehaviour type exists in the scene.
/// If an instance does not exist, it creates a new GameObject and adds the required component to it.
/// </summary>
/// <typeparam name="T">The specific Component type that this class will manage.</typeparam>
public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    /// <summary>
    /// Provides access to the singleton instance of this MonoBehaviour.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}

/// <summary>
/// This class provides a Singleton pattern implementation for MonoBehaviour.
/// It ensures that only one instance of a MonoBehaviour type exists across multiple scenes.
/// If an instance does not exist, it sets the current instance as the singleton instance and prevents it from being destroyed on load.
/// If an instance already exists, it destroys the new instance.
/// </summary>
/// <typeparam name="T">The specific Component type that this class will manage.</typeparam>
public class MonoBehaviourSingletonPersistent<T> : MonoBehaviour where T : Component
{
    /// <summary>
    /// Provides access to the singleton instance of this MonoBehaviour.
    /// </summary>
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

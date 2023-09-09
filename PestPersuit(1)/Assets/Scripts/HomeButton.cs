using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public void GoHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

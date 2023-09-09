using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{
    public void SelectLevel1()
    {
        // Debug
        Debug.Log("Level 1 selected");
        // Load the next scene in the build order
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}

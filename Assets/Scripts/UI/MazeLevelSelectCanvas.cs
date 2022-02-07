using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeLevelSelectCanvas : MonoBehaviour
{
    [SerializeField]
    private SceneLoaderContainer sceneLoaderContainer;
        
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(sceneLoaderContainer.MainMenuPath);
    }
}

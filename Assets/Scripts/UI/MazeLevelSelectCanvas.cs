using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeLevelSelectCanvas : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private SceneLoaderContainer sceneLoaderContainer;

    #endregion

    #region Public Methods

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(sceneLoaderContainer.MainMenuPath);
    }

    public void GoToMazeScene()
    {
        SceneManager.LoadScene(sceneLoaderContainer.LevelScenePath);
    }

    #endregion
}
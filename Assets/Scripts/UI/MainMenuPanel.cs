using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private SceneLoaderContainer sceneLoaderContainer;

    #endregion

    #region Unity Callbacks

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    #endregion

    #region Public Methods

    public void PlayMazeGame()
    {
        SceneManager.LoadScene(sceneLoaderContainer.MazeLevelSelectionPath);
    }
    
    public void ReadInstruction()
    {
        SceneManager.LoadScene(sceneLoaderContainer.InstructionPath);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
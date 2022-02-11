using UI.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MazeLevelSelectCanvas : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;

        #endregion

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoBackToMenu();
            }
        }
        
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
}
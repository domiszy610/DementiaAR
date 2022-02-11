using UI.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuPanel : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;

        #endregion

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }
        }

        #region Public Methods

        public void PlayMazeGame()
        {
            SceneManager.LoadScene(sceneLoaderContainer.MazeLevelSelectionPath);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion
    }
}
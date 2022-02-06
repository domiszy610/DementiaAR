using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;
        
        public void PlayMazeGame()
        {
            SceneManager.LoadScene(sceneLoaderContainer.MazeLevelSelectionPath);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    
    }
}

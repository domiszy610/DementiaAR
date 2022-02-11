using UI.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MazeLevelCanvas : MonoBehaviour
    {
        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoBackToMenu();
            }
        }
        
        public void GoBackToMenu()
        {
            SceneManager.LoadScene(sceneLoaderContainer.MainMenuPath);
        }
    }
}

using System.Collections;
using ScriptableObjects;
using UnityEngine;

namespace MazeGameplay
{
    public class HandleEnd : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private float winEffectTime;

        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;

        [SerializeField]
        private PanelChannel panelChannel;

        #endregion

        #region Private Fields

        private int currentLevel;

        #endregion

        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                StartCoroutine(Win());
            }
        }

        #endregion

        #region Private Methods

        private IEnumerator Win()
        {
            currentLevel = sceneLoaderContainer.CurrentLevelIndex;

            if (sceneLoaderContainer.LevelCount == currentLevel + 1)
            {
                EndGame();

                yield break;
            }

            panelChannel.IsWinPanelActive = true;

            yield return new WaitForSeconds(winEffectTime);

            panelChannel.IsWinPanelActive = false;

            sceneLoaderContainer.CurrentLevelIndex = currentLevel + 1;

            if (sceneLoaderContainer.UnlockedLevelIndex < sceneLoaderContainer.CurrentLevelIndex)
            {
                sceneLoaderContainer.UnlockedLevelIndex = sceneLoaderContainer.CurrentLevelIndex;
            }
        }

        private void EndGame()
        {
            DisableMaze();
            panelChannel.IsEndPanelActive = true;
            sceneLoaderContainer.UnlockedLevelIndex = currentLevel;
        }

        private void DisableMaze()
        {
            transform.parent.parent.gameObject.SetActive(false);
        }

        #endregion
    }
}
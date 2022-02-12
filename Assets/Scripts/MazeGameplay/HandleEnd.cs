using System.Collections;
using UI.ScriptableObjects;
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

        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            StartCoroutine(Win());
        }

        #endregion

        #region Private Methods

        private IEnumerator Win()
        {
            panelChannel.IsWinPanelActive = true;
            int currentLevel = sceneLoaderContainer.CurrentLevelIndex;

            yield return new WaitForSeconds(winEffectTime);

            panelChannel.IsWinPanelActive = false;

            if (sceneLoaderContainer.LevelCount == sceneLoaderContainer.CurrentLevelIndex)
            {
                EndGame();

                yield break;
            }

            sceneLoaderContainer.CurrentLevelIndex = currentLevel + 1;

            if (sceneLoaderContainer.UnlockedLevelIndex < sceneLoaderContainer.CurrentLevelIndex)
            {
                sceneLoaderContainer.UnlockedLevelIndex = sceneLoaderContainer.CurrentLevelIndex;
            }
        }

        private void EndGame()
        {
            panelChannel.IsEndPanelActive = true;
        }

        #endregion
    }
}
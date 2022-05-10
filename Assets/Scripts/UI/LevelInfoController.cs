using ScriptableObjects;
using TMPro;
using UnityEngine;


public class LevelInfoController : MonoBehaviour
{
        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;
        [SerializeField]
        private TextMeshProUGUI levelInfoText;

        private int currentIndex;

        private void Awake()
        {
                currentIndex = GetCurrentLevelIndex();
                ChangeLevelText(currentIndex);
                sceneLoaderContainer.OnModifiedCurrentLevel += NextLevel;
        }

        private void OnDisable()
        {
                sceneLoaderContainer.OnModifiedCurrentLevel -= NextLevel;
        }

        private void NextLevel()
        {
                currentIndex = GetCurrentLevelIndex();
                ChangeLevelText(currentIndex);
        }

        private void ChangeLevelText(int currentLevelIndex)
        {
                int level = currentLevelIndex + 1;
                levelInfoText.text = "POZIOM " + level.ToString();
        }


        private int GetCurrentLevelIndex() => sceneLoaderContainer.CurrentLevelIndex;
}
using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "SceneContainer", fileName = "SceneLoaderContainer")]
    public class SceneLoaderContainer : ScriptableObject
    {
        #region Events

        public event Action OnModifiedCurrentLevel;

        #endregion

        #region Serialized Fields

        [SerializeField]
        private string levelScenePath;

        [SerializeField]
        private string mainMenuPath;

        [SerializeField]
        private string mazeLevelSelectionPath;
        
        [SerializeField]
        private string instructionPath;

        [SerializeField]
        private int levelCount;

        #endregion

        #region Private Fields

        private int currentLevelIndex;

        private int unlockedLevelIndex;

        #endregion

        #region Public Properties

        public string LevelScenePath => levelScenePath;
        public string MainMenuPath => mainMenuPath;
        public string MazeLevelSelectionPath => mazeLevelSelectionPath;
        
        public string InstructionPath => instructionPath;

        public int CurrentLevelIndex {
            get => currentLevelIndex;
            set
            {
                currentLevelIndex = value;
                OnModifiedCurrentLevel?.Invoke();
            }
        }

        public int UnlockedLevelIndex {
            get => unlockedLevelIndex;
            set
            {
                unlockedLevelIndex = value;
                PlayerPrefs.SetInt("UnlockedMazeLevelIndex", value);
            }
        }

        public int LevelCount { get => levelCount; set => levelCount = value; }

        #endregion
    }
}
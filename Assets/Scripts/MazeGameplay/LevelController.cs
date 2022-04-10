using System;
using System.Collections.Generic;
using MazeInitialization;
using UI.ScriptableObjects;
using UnityEngine;

namespace MazeGameplay
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private MazeConstructor mazeConstructor;
        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;
        
        #region Events

        public event Action OnChangedMazeLevel;

        #endregion
        
        private GameObject mazeObject;
        private int currentIndex;
        private List<GameObject> mazeObjects;
        
        public GameObject MazeObject => mazeObject;

        public int CurrentIndex => currentIndex;
        private void Start()
        {
            mazeObjects = mazeConstructor.MazeObjects;
            currentIndex = GetCurrentLevelIndex();
            GetMazeObject(currentIndex);
            sceneLoaderContainer.OnModifiedCurrentLevel += NextGameObject;
        }
        private void OnDisable()
        {
            sceneLoaderContainer.OnModifiedCurrentLevel -= NextGameObject;
        }
        private void GetMazeObject(int index)
        {
            mazeObject = mazeObjects[index];
            mazeObject.SetActive(true);
        }

        private void NextGameObject()
        {
            Destroy(mazeObject);
            currentIndex = GetCurrentLevelIndex();
            GetMazeObject(currentIndex);
            OnChangedMazeLevel?.Invoke();
        }

        private int GetCurrentLevelIndex() => sceneLoaderContainer.CurrentLevelIndex;

        
    }
}

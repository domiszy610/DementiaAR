using System.Collections.Generic;
using UI.ScriptableObjects;
using UnityEngine;

namespace MazeInitialization
{
    public class MazeConstructor : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private List<GameObject> mazePrefabs;
        [SerializeField]
        private Vector3 mazePosition;
        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;

        #endregion

        #region Private Fields

        private List<GameObject> mazeObjects;

        #endregion

        public List<GameObject> MazeObjects => mazeObjects;

        #region Unity Callbacks

        private void Awake()
        {
            ConstructMazes();
        }

        #endregion

        #region Private Methods

        private void ConstructMazes()
        {
            mazeObjects = new List<GameObject>();

            foreach (GameObject mazePrefab in mazePrefabs)
            {
                GameObject newMaze = Instantiate(mazePrefab, mazePosition, mazePrefab.transform.rotation);
                newMaze.SetActive(false);
                mazeObjects.Add(newMaze);
            }

            sceneLoaderContainer.LevelCount = mazeObjects.Count - 1;
        }

        #endregion
    }
}
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
                GameObject newMaze = Instantiate(mazePrefab, mazePosition, Quaternion.identity);
                newMaze.SetActive(false);
                mazeObjects.Add(newMaze);
            }

            sceneLoaderContainer.LevelCount = mazeObjects.Count - 1;
        }

        #endregion
    }
}
using System.Collections.Generic;
using UI.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace MazeInitialization
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class MazeSpawner : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private MazeConstructor mazeConstructor;
        [SerializeField]
        private GameObject instructionPanel;
        [SerializeField]
        private Button dismissButton;
        [SerializeField]
        private Camera arCamera;
        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer;

        #endregion

        #region Private Fields

        private Vector3 mazePosition = new Vector3(0.5f, 0.75f, 0f);

        private ARRaycastManager arRaycastManager;

        private static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

        private GameObject mazeObject;

        private int currentIndex;

        private List<GameObject> mazeObjects;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            arRaycastManager = GetComponent<ARRaycastManager>();
        }

        private void Start()
        {
            mazeObjects = mazeConstructor.MazeObjects;
            currentIndex = GetCurrentLevelIndex();

            if (currentIndex == 0)
            {
                instructionPanel.SetActive(true);
                dismissButton.onClick.AddListener(Dismiss);
            }

            GetMazeObject(currentIndex);
            sceneLoaderContainer.OnModifiedCurrentLevel += NextGameObject;
        }

        private void OnDisable()
        {
            sceneLoaderContainer.OnModifiedCurrentLevel -= NextGameObject;
        }

        private void Update()
        {
            if (mazeObject && Input.touchCount <= 0)
            {
                if (arRaycastManager.Raycast(arCamera.ViewportPointToRay(mazePosition), raycastHits, TrackableType.PlaneWithinPolygon))
                {
                    MoveMazeObject();
                }
            }
        }

        #endregion

        #region Private Methods

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
        }

        private void Dismiss()
        {
            instructionPanel.SetActive(false);
        }

        private void MoveMazeObject()
        {
            Pose hitPose = raycastHits[0].pose;
            mazeObject.transform.position = hitPose.position;
        }

        private int GetCurrentLevelIndex() => sceneLoaderContainer.CurrentLevelIndex;

        #endregion
    }
}
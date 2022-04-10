using System.Collections.Generic;
using MazeGameplay;
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
        private GameObject instructionPanel;
        [SerializeField]
        private Button dismissButton;
        [SerializeField]
        private Camera arCamera;
        [SerializeField]
        private LevelController levelController;
        

        #endregion

        #region Private Fields

        private Vector3 mazePosition = new Vector3(0.5f, 0.75f, 0f);

        private ARRaycastManager arRaycastManager;

        private static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

        private GameObject mazeObject;

        private int currentIndex;
        

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            arRaycastManager = GetComponent<ARRaycastManager>();
        }

        private void Start()
        {
            currentIndex = GetCurrentLevelIndex();

            if (currentIndex == 0)
            {
                instructionPanel.SetActive(true);
                dismissButton.onClick.AddListener(Dismiss);
            }

            GetMazeObject();
            levelController.OnChangedMazeLevel += GetMazeObject;
        }

        private void OnDisable()
        {
            levelController.OnChangedMazeLevel -= GetMazeObject;
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

        private void GetMazeObject()
        {
            mazeObject = levelController.MazeObject;
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

        private int GetCurrentLevelIndex() => levelController.CurrentIndex;

        #endregion
    }
}
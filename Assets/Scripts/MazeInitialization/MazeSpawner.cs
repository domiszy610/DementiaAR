using System.Collections.Generic;
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
        private GameObject mazePrefab;
        [SerializeField]
        private GameObject instructionPanel;
        [SerializeField]
        private Button dismissButton;
        [SerializeField]
        private Camera arCamera;

        #endregion

        #region Private Fields

        private Vector3 mazePosition = new Vector3(0.5f, 0.5f, 0f);

        private ARRaycastManager arRaycastManager;

        private static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            arRaycastManager = GetComponent<ARRaycastManager>();
            dismissButton.onClick.AddListener(Dismiss);
        }

        private void Update()
        {
            if (mazePrefab)
            {
                if (arRaycastManager.Raycast(arCamera.ViewportPointToRay(mazePosition), raycastHits, TrackableType.PlaneWithinPolygon))
                {
                    MoveMazeObject();
                }
            }
        }

        #endregion

        #region Private Methods

        private void Dismiss() => instructionPanel.SetActive(false);

        private void MoveMazeObject()
        {
            Pose hitPose = raycastHits[0].pose;
            mazePrefab.transform.position = hitPose.position;
        }

        #endregion
    }
}
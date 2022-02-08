using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace MazeInitialization
{
    [RequireComponent((typeof(ARSessionOrigin)))]
    public class MazeSpawner : MonoBehaviour
    {

        private GameObject spawnedMaze;
        private GameObject spawnedSphere;

        [SerializeField]
        private GameObject placeblePrefab;

        private ARSessionOrigin sessionOrigin;
        private ARRaycastManager raycastManager;
        private static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        private void Awake()
        {
            sessionOrigin = GetComponent<ARSessionOrigin>();
            raycastManager = sessionOrigin.GetComponent<ARRaycastManager>();

        }

        private void Update()
        {
            if (raycastManager.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), s_Hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = s_Hits[0].pose;
                placeblePrefab.transform.position = hitPose.position;

                if (!placeblePrefab.activeSelf)
                {
                    placeblePrefab.SetActive(true);
                }
            }
        }
 
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace MazeInitialization
{
    [RequireComponent((typeof(ARPlaneManager)))]
    public class MazeSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject mazePrefab;
        // [SerializeField]
        // private GameObject spawnedSphere;

        [SerializeField]
        private GameObject instructionPanel;
        [SerializeField]
        private Button dismissButton;

       
        private GameObject placeablePrefab;



        [SerializeField]
        private ARPlaneManager arPlaneManager;
        
        

        private void Awake()
        {
            dismissButton.onClick.AddListener(Dismiss);
            arPlaneManager = GetComponent<ARPlaneManager>();

            arPlaneManager.planesChanged += PlaneChanged;
        }

        private void Dismiss() => instructionPanel.SetActive(false);

        private void PlaneChanged(ARPlanesChangedEventArgs args)
        {
            if (args.added != null && placeablePrefab == null)
            {
                ARPlane arPlane = args.added[0];
                placeablePrefab = Instantiate(mazePrefab, arPlane.transform.position, Quaternion.identity);
                
            }
        }
 
    }
}

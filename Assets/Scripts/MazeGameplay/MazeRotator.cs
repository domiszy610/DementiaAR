using System.Collections.Generic;
using MazeInitialization;
using UI.ScriptableObjects;
using UnityEngine;

namespace MazeGameplay
{
    public class MazeRotator : MonoBehaviour
    {
        [SerializeField]
        private Camera arCamera;
        [SerializeField]
        private LevelController levelController;

        private GameObject mazeObject;

        private void Start()
        {
            levelController.OnChangedMazeLevel += GetMazeObject;
        }
        private void OnDisable()
        {
            levelController.OnChangedMazeLevel += GetMazeObject;
        }

        private void Update()
        {
            if (mazeObject)
            {
                mazeObject.transform.rotation = Quaternion.LookRotation(transform.position - arCamera.transform.position, Vector3.left);
            }
        }
        private void GetMazeObject()
        {
            mazeObject = levelController.MazeObject;
        }
        
    }
}

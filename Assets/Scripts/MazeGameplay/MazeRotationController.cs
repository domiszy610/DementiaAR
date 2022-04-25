using UI;
using UI.ScriptableObjects;
using UnityEngine;

namespace MazeGameplay
{
    public class MazeRotationController : MonoBehaviour
    {
        #region Private Fields

        [SerializeField]
        private MazeRotationChannel mazeRotationChannel;

        #endregion

        #region Unity Callbacks
        

        private void Update()
        {
            if (mazeRotationChannel.rotationStatus == RotationDirection.Left)
            {
                RotateLeft();
            }
            if (mazeRotationChannel.rotationStatus == RotationDirection.Right)
            {
                RotateRight();
            }
        }
        
        #endregion
        

        #region Private Methods
        
        private void RotateLeft()
        {
            Rotate(false);
        }
        private void RotateRight()
        {
            Rotate(true);
        }

        private void Rotate(bool rightRotation)
        {
            if (rightRotation)
            {
                Debug.Log("Rotate Right");
                transform.Rotate(Vector3.forward, Time.deltaTime * 80f);
            }
            else
            {
                Debug.Log("Rotate Left");
                transform.Rotate(Vector3.back, Time.deltaTime * 80f);
            }
        }

        #endregion
    }
}
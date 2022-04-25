using UI.Enums;
using UI.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RotationButtonsController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private MazeRotationChannel mazeRotationChannel;

        [SerializeField]
        private Button leftRotationButton;

        [SerializeField]
        private Button rightRotationButton;

        #endregion

        #region Public Methods

        public void OnLeftRotationButtonPressed()
        {
            rightRotationButton.interactable = false;
            mazeRotationChannel.rotationStatus = RotationDirection.Left;
            Debug.Log("Pressed Left");
        }

        public void OnLeftRotationButtonReleased()
        {
            rightRotationButton.interactable = true;
            mazeRotationChannel.rotationStatus = RotationDirection.None;
            Debug.Log("Released Left");
        }

        public void OnRightRotationButtonPressed()
        {
            leftRotationButton.interactable = false;
            mazeRotationChannel.rotationStatus = RotationDirection.Right;
            Debug.Log("Pressed Right");
        }

        public void OnRightRotationButtonReleased()
        {
            leftRotationButton.interactable = true;
            mazeRotationChannel.rotationStatus = RotationDirection.None;
            Debug.Log("Released Right");
        }

        #endregion
    }
}
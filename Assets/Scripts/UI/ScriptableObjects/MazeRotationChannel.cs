using UI.Enums;
using UnityEngine;

namespace UI.ScriptableObjects
{
    [CreateAssetMenu(menuName = "MazeRotationChannel", fileName = "MazeRotationChannel")]
    public class MazeRotationChannel : ScriptableObject
    {
        public RotationDirection rotationStatus;

        #region Unity Callbacks

        private void Awake()
        {
            rotationStatus = RotationDirection.None;
        }

        #endregion
    }
}
using UnityEngine;

namespace UI.ScriptableObjects
{
    [CreateAssetMenu(menuName = "MazeRotationChannel", fileName = "MazeRotationChannel")]
    public class MazeRotationChannel : ScriptableObject
    {
        public RotationDirection rotationStatus;

        private void Awake()
        {
            rotationStatus = RotationDirection.None;
        }

    }
}

using UnityEngine;

namespace MazeGameplay
{
    public class MazeRotator : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Camera arCamera;
        [SerializeField]
        private LevelController levelController;

        #endregion

        #region Private Fields

        private GameObject mazeObject;

        #endregion

        #region Unity Callbacks

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
                mazeObject.transform.rotation = Quaternion.LookRotation(transform.position - arCamera.transform.position);
            }
        }

        #endregion

        #region Private Methods

        private void GetMazeObject()
        {
            mazeObject = levelController.MazeObject;
        }

        #endregion
    }
}
using UnityEngine;

namespace MazeGameplay
{
    public class MazeRotationController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private float rotationPower;
        [SerializeField]
        private float rotationSpeed;

        #endregion

        #region Private Fields

        private float angleY;
        private float angleX;
        private Touch screenTouch;
        private Vector2 input;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                screenTouch = Input.GetTouch(0);
                input = screenTouch.deltaPosition;
                RotateMaze();
            }
        }

        #endregion

        #region Private Methods

        private void RotateMaze()
        {
            angleY += input.x * rotationPower * Time.deltaTime;
            angleY = Mathf.Clamp(angleY, -90.0f, 90.0f);

            angleX += input.y * rotationPower * Time.deltaTime;
            angleX = Mathf.Clamp(angleX, -45.0f, 45.0f);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-angleX, -angleY, 0.0f), Time.deltaTime * rotationSpeed);
        }

        #endregion
    }
}
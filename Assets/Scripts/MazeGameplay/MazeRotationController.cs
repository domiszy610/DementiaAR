using UnityEngine;

namespace MazeGameplay
{
    public class MazeRotationController : MonoBehaviour
    {
        [SerializeField]
        private float rotationPower;
        [SerializeField]
        private float rotationSpeed;

        private float angleY = 0.0f;
        private float angleX = 0.0f;
        private Touch screenTouch;
        private Vector2 input;
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                screenTouch = Input.GetTouch(0);
                input = screenTouch.deltaPosition;
                RotateMaze();
            }
        
        }
        
        void RotateMaze()
        {
            angleY += input.x * rotationPower*Time.deltaTime;
            angleY = Mathf.Clamp(angleY, -90.0f, 90.0f);
            
            angleX += input.y * rotationPower*Time.deltaTime;
            angleX = Mathf.Clamp(angleX, -45.0f, 45.0f);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-angleX, -angleY, 0.0f), Time.deltaTime*rotationSpeed);
        }
        
    }
}

using UnityEngine;

namespace MazeGameplay
{
    public class MazeRotationController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                RotateMaze();
            }
        
        }

        private void RotateMaze()
        {
            Touch screenTouch = Input.GetTouch(0);
            transform.Rotate(screenTouch.deltaPosition.y, screenTouch.deltaPosition.x, 0f);

        }
    }
}

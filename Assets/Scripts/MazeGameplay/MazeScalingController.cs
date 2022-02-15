using UnityEngine;

namespace MazeGameplay
{
    public class MazeScalingController : MonoBehaviour
    {

        [Space]
        public float minScale;
        public float maxScale;
 
        private float initialFingersDistance;
        private Vector3 initialScale;
    
        void Update()
        {
            if (Input.touches.Length == 2)
            {
                Scaling();
            }
        }
    
        void Scaling()
        {
            if (Input.touches.Length == 2)
            {
                Touch t1 = Input.touches[0];
                Touch t2 = Input.touches[1];
 
                if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
                {
                    initialFingersDistance = Vector2.Distance(t1.position, t2.position);
                    initialScale = transform.localScale;
                }
                else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
                {
 
                    float currentFingersDistance = Vector2.Distance(t1.position, t2.position);
                    var scaleFactor = currentFingersDistance / initialFingersDistance;
 
                    Vector3 scale= initialScale * scaleFactor;
 
                    scale.x = Mathf.Clamp(scale.x, minScale,maxScale);
                    scale.y = Mathf.Clamp(scale.y, minScale, maxScale);
                    scale.z = Mathf.Clamp(scale.z, minScale, maxScale);
                    transform.localScale = scale;
                }
            }
 
        }
    }
}

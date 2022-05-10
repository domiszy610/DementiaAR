using UnityEngine;

namespace ARCamera
{
    [ExecuteAlways]
    public class ARCameraMatcher : MonoBehaviour
    {
        [SerializeField]
        private Camera baseCamera;
     
        private Camera overlayCamera;
     
        private void OnEnable()
        {
            overlayCamera = GetComponent<Camera>();
        }
     
        private void OnPreRender()
        {
            if (overlayCamera == null)
            {
                return;
            }
            if (baseCamera == null)
            {
                return;
            }
            overlayCamera.projectionMatrix = baseCamera.projectionMatrix;
     
        }
    }
}

using System.Collections;
using UnityEngine;

namespace MazeGameplay
{
    public class HandleEnd : MonoBehaviour
    {
        [SerializeField]
        private GameObject winPanel;
        
        [SerializeField]
        private float effectTime;

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            StartCoroutine(Win());
        }

        private IEnumerator Win()
        {
            winPanel.SetActive(true);

            yield return new WaitForSeconds(effectTime);

            winPanel.SetActive(false);
        }
    }
}

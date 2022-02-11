using System.Collections;
using UnityEngine;

namespace MazeGameplay
{
    public class HandleEnd : MonoBehaviour
    {
        [SerializeField]
        private GameObject winPanel;
        [SerializeField]
        private GameObject winEffect;
        [SerializeField]
        private AudioSource audioSource;
        
        [SerializeField]
        private float effectTime;

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            StartCoroutine(Win());
        }

        private IEnumerator Win()
        {
            audioSource.Play();
            winPanel.SetActive(true);
            winEffect.SetActive(true);

            yield return new WaitForSeconds(effectTime);

            audioSource.Stop();
            winPanel.SetActive(false);
            winEffect.SetActive(false);
        }
    }
}

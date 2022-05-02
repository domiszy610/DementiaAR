using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeLevelCanvas : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private SceneLoaderContainer sceneLoaderContainer;
    [SerializeField]
    private PanelChannel panelChannel;
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject endPanel;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        panelChannel.OnModifiedEndPanelActive += ShowEndPanel;
        panelChannel.OnModifiedWinPanelActive += ShowWinPanel;
    }

    private void OnDisable()
    {
        panelChannel.OnModifiedEndPanelActive -= ShowEndPanel;
        panelChannel.OnModifiedWinPanelActive -= ShowWinPanel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBackToLevelSelection();
        }
    }

    #endregion

    #region Public Methods

    public void GoBackToLevelSelection()
    {
        SceneManager.LoadScene(sceneLoaderContainer.MazeLevelSelectionPath);
    }

    #endregion

    #region Private Methods

    private void ShowEndPanel()
    {
        endPanel.SetActive(panelChannel.IsEndPanelActive);
    }

    private void ShowWinPanel()
    {
        winPanel.SetActive(panelChannel.IsWinPanelActive);
    }

    #endregion
}
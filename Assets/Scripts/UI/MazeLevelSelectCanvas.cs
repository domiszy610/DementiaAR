using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeLevelSelectCanvas : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private SceneLoaderContainer sceneLoaderContainer;
    [SerializeField]
    private GameObject levelSelectionPanel;

    #endregion

    #region Private Fields

    private List<Button> levelSelectionButtons;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        levelSelectionButtons = GetButtonsList();
        UnlockButtons(levelSelectionButtons);
        AttachOnClickListeners(levelSelectionButtons);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBackToMenu();
        }
    }

    #endregion

    #region Public Methods

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(sceneLoaderContainer.MainMenuPath);
    }

    public void GoToMazeScene()
    {
        SceneManager.LoadScene(sceneLoaderContainer.LevelScenePath);
    }

    #endregion

    #region Private Methods

    private void UnlockButtons(List<Button> buttons)
    {
        int unlockedLevelsIndex = GetUnlockedLevelsIndex();

        for (int i = 0; i <= unlockedLevelsIndex; i++)
        {
            buttons[i].interactable = true;
        }
    }

    private void AttachOnClickListeners(List<Button> buttons)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => { ChangeLevel(index); });
        }
    }

    private void ChangeLevel(int levelIndex)
    {
        sceneLoaderContainer.CurrentLevelIndex = levelIndex;
        GoToMazeScene();
    }

    private List<Button> GetButtonsList() => levelSelectionPanel.GetComponentsInChildren<Button>().ToList();

    private int GetUnlockedLevelsIndex() => PlayerPrefs.GetInt("UnlockedMazeLevelIndex");

    #endregion
}
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneContainer", fileName = "SceneLoaderContainer")]
public class SceneLoaderContainer : ScriptableObject
{
    #region Events

    public event Action OnModified;

    #endregion

    #region Serialized Fields

    [SerializeField]
    private string levelScenePath;

    [SerializeField]
    private string mainMenuPath;

    [SerializeField]
    private string mazeLevelSelectionPath;

    [SerializeField]
    private string loadingScreenPath;

    #endregion

    #region Private Fields

    private int currentLevel;

    #endregion

    #region Public Properties

    public string LevelScenePath { get => levelScenePath; }
    public string MainMenuPath { get => mainMenuPath; }
    public string MazeLevelSelectionPath { get => mazeLevelSelectionPath; }

    public int CurrentLevel {
        get => currentLevel;
        set
        {
            currentLevel = value;
            OnModified?.Invoke();
        }
    }

    #endregion
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SceneContainer", fileName = "SceneLoaderContainer")]
public class SceneLoaderContainer: ScriptableObject
{
    #region Events

    public event Action OnModified;

   #endregion
   
   [SerializeField]
   private string levelScenePath;
   
   [SerializeField]
   private string mainMenuPath;
   
   [SerializeField]
   private string mazeLevelSelectionPath;
   
   [SerializeField]
   private string loadingScreenPath;
   
   private int currentLevel;
   
   public string LevelScenePath { get => levelScenePath;}
   public string MainMenuPath { get => mainMenuPath;}
   public string MazeLevelSelectionPath { get => mazeLevelSelectionPath;}
   public string LoadingScreenPath { get => loadingScreenPath;}
   
 
   public int CurrentLevel {
               get => currentLevel;
               set
               {
                   this.currentLevel = value;
                   OnModified?.Invoke();
               }
           }
}

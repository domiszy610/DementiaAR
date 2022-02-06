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
   
 
   public int CurrentLevel {
               get => currentLevel;
               set
               {
                   this.currentLevel = value;
                   OnModified?.Invoke();
               }
           }
}

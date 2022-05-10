using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionCanvas : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private SceneLoaderContainer sceneLoaderContainer;

    #endregion

    #region Private Fields

    private List<Button> levelSelectionButtons;

    #endregion

    #region Unity Callbacks

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


    #endregion
}

  
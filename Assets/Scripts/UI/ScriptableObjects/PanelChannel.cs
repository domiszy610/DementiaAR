using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "PanelChannel", fileName = "PanelChannel")]
    public class PanelChannel : ScriptableObject
    {
        #region Events

        public event Action OnModifiedEndPanelActive;
        public event Action OnModifiedWinPanelActive;

        #endregion

        #region Private Fields

        private bool isEndPanelActive;
        private bool isWinPanelActive;

        #endregion

        #region Public Properties

        public bool IsEndPanelActive {
            get => isEndPanelActive;
            set
            {
                isEndPanelActive = value;
                OnModifiedEndPanelActive?.Invoke();
            }
        }

        public bool IsWinPanelActive {
            get => isWinPanelActive;
            set
            {
                isWinPanelActive = value;
                OnModifiedWinPanelActive?.Invoke();
            }
        }

        #endregion
    }
}
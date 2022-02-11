using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UI.ScriptableObjects
{

[CreateAssetMenu(menuName = "PanelChannel", fileName = "PanelChannel")]
    public class PanelChannel : ScriptableObject
    {
        public event Action OnModifiedEndPanelActive;
        public event Action OnModifiedWinPanelActive;
      
        private bool isEndPanelActive;
        private bool isWinPanelActive;
        
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


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class SettingsView : MonoBehaviour
    {

        [SerializeField] private Button backToMenuButton;

        public void InitExitButton (UnityAction toMenu)
        {
            backToMenuButton.onClick.AddListener (toMenu);
        }
        private void OnDestroy()
        {
            backToMenuButton.onClick.RemoveAllListeners();
        }
    }
}
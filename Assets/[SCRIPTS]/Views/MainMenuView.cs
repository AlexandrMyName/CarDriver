using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonStart;
        [SerializeField]
        private Button _buttonSettings;

        public void Init(UnityAction startGame)
        {
           
            _buttonStart.onClick.AddListener(startGame);
        }
        public void InitSettings(UnityAction inSettings)
        {

            _buttonSettings.onClick.AddListener(inSettings);
        }
        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
        }
    }
}
using Profile;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class SettingsController : BaseController
    {

        private readonly ProfilePlayer _profilePlayer;
        private readonly SettingsView _view;
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/settings" };

        public SettingsController(Transform placeForUi, ProfilePlayer
        profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.InitExitButton(ToMenu);
            
        }

        private SettingsView LoadView(Transform placeForUI)
        {
            GameObject objectView =
           Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUI, false);
            AddGameObjects(objectView);
            if (objectView != null) Debug.Log("Инициализирован");
            return objectView.GetComponent<SettingsView>();
        }
        private void ToMenu() => _profilePlayer.CurrentState.Value = GameState.Start;
    }
}
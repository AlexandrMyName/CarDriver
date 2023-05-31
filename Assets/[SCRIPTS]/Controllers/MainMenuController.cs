using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };

        public MainMenuController(Transform placeForUi, ProfilePlayer
        profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
            _view.InitSettings(OnSettings);
        }
        
        
        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView =
            Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            if (objectView != null) Debug.Log("Инициализирован");
            return objectView.GetComponent<MainMenuView>();
        }
        private void StartGame() => _profilePlayer.CurrentState.Value = GameState.Game;

        private void OnSettings() => _profilePlayer.CurrentState.Value = GameState.Settings;

    }
}

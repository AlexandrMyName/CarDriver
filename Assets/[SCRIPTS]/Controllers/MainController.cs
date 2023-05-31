using Profile;
using System.Collections;
using System.Collections.Generic;
using Ui;
using Game;
using UnityEngine;

internal class MainController : BaseController
{
    private readonly Transform _placeForUI;
    private readonly ProfilePlayer _playerProfile;

    private MainMenuController _menuController;
    private SettingsController _settingsController;
    private GameController _gameController;

    public MainController(Transform placeForUIm, ProfilePlayer playerProfile)
    {
        _placeForUI = placeForUIm;
        _playerProfile = playerProfile;

        _playerProfile.CurrentState.SubscribeOnChange(OnChangeGameState);
        Debug.Log("Подготовка гл контроллера");
        OnChangeGameState(_playerProfile.CurrentState.Value);
    }

    protected override void OnDispose()
    {
       _menuController?.Dispose();
        _gameController?.Dispose();
        _settingsController?.Dispose();
        _playerProfile.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
    }
    private void OnChangeGameState(GameState state)
    {
        Debug.Log("Вход в менеджер состояний");
        switch (state)
        {
            case GameState.Start:
                _menuController = new MainMenuController(_placeForUI, _playerProfile);
                _gameController?.Dispose();
                _settingsController?.Dispose();
                break;

            case GameState.Game:
                _gameController = new GameController(_playerProfile);
                _menuController?.Dispose();
                _settingsController?.Dispose();

                break;

            case GameState.Settings:
                Debug.Log("To settings");
                _menuController?.Dispose();
                _gameController?.Dispose();
                _settingsController = new SettingsController(_placeForUI,_playerProfile);
               

                break;

            default:
                _menuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }
}

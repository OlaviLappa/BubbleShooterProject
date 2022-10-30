using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Scenes;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button[] _gameMenuButtons;
    [SerializeField] private GameObject _gameMenuPanel;

    private SceneManagerBase sceneManagerBase;

    private void Start()
    {
        sceneManagerBase = new SceneManagerBase();
        _gameMenuPanel.SetActive(false);

        _gameMenuButtons[0].onClick.AddListener(() => OpenGameMenu());
        _gameMenuButtons[1].onClick.AddListener(() => CloseGameMenu());
        _gameMenuButtons[2].onClick.AddListener(() => ReloadLevel());
        _gameMenuButtons[3].onClick.AddListener(() => LeaveGame());
    }

    private void OpenGameMenu() => _gameMenuPanel.SetActive(true);
    private void CloseGameMenu() => _gameMenuPanel.SetActive(false);
    private void ReloadLevel() => sceneManagerBase.LoadNewSceneRoutine("Game");
    private void LeaveGame() => sceneManagerBase.LoadNewSceneRoutine("MainMenu");
}
using UnityEngine;
using Assets.Scripts.Scenes;
using UnityEngine.UI;

public class GameConfiguration : MonoBehaviour
{
    private SceneManagerBase sceneManagerBase;
    [SerializeField] Button[] _menuButtons;

    void Start()
    {
        sceneManagerBase = new SceneManagerBase();
        _menuButtons[0].onClick.AddListener(() => StartGameHandler());
        _menuButtons[3].onClick.AddListener(() => QuitGameHandler());
    }

    private void StartGameHandler()
    {
        sceneManagerBase.LoadNewSceneRoutine("Game");
    }

    private void QuitGameHandler()
    {
        Debug.Log("Quit from game");
    }
}

using Controllers;
using UI.Menus;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : GameMenu
{
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnResume.onClick.AddListener(Resume);
        btnExit.onClick.AddListener(Exit);
    }

    private void Resume()
    {
        CoreController.Instance.GameManager.TogglePause(false);
    }

    private void Exit()
    {
        CoreController.Instance.GameManager.ExitToMenu();
    }
}

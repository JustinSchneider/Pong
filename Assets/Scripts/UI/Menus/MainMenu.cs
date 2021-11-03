using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus
{
    public class MainMenu: GameMenu
    {
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnExit;

        private void Awake()
        {
            btnPlay.onClick.AddListener(Play);
            btnExit.onClick.AddListener(Exit);
        }

        private void Play()
        {
            CoreController.Instance.UiManager.ShowMenu(Constants.Menu.HUD, true);
            CoreController.Instance.GameManager.StartNewGame();
        }

        private void Exit()
        {
            CoreController.Instance.GameManager.QuitGame();
        }
    }
}
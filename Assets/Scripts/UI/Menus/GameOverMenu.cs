using Constants;
using Controllers;
using TMPro;
using UI.Menus;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : GameMenu
{
    [SerializeField] private TMP_Text txtWinText;
    [SerializeField] private Button btnPlayAgain;

    private void Awake()
    {
        btnPlayAgain.onClick.AddListener(PlayAgain);
    }

    private void PlayAgain()
    {
        CoreController.Instance.UiManager.ShowMenu(Menu.HUD, true);
        CoreController.Instance.GameManager.StartNewGame();
    }

    public void ShowWin(int playerId)
    {
        txtWinText.text = $"Player {playerId} Wins";
    }
}

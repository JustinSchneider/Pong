using Controllers;
using TMPro;
using UnityEngine;

namespace UI.Menus
{
    public class Hud: Menu
    {
        [SerializeField] private TMP_Text txtPlayer1Score;
        [SerializeField] private TMP_Text txtPlayer2Score;
        
        public void UpdateScores()
        {
            txtPlayer1Score.text = CoreController.Instance.GameManager.Player1Score.ToString("00");
            txtPlayer2Score.text = CoreController.Instance.GameManager.Player2Score.ToString("00");
        }
    }
}
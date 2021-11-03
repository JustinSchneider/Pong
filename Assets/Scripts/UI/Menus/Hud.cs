using System.Collections;
using Controllers;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Menus
{
    public class Hud: GameMenu
    {
        [SerializeField] private TMP_Text txtPlayer1Score;
        [SerializeField] private TMP_Text txtPlayer2Score;
        [SerializeField] private TMP_Text txtCountdown;

        public void UpdateScore(int player)
        {
            if (player == 1)
            {
                Color32 origColor = txtPlayer1Score.color;
                txtPlayer1Score.color = new Color32(0xff, 0xff, 0x00, 0x00);
                txtPlayer1Score.text = CoreController.Instance.GameManager.player1Score.ToString("00");
                txtPlayer1Score.DOColor(origColor, 1f);
            }
            else
            {
                Color32 origColor = txtPlayer2Score.color;
                txtPlayer2Score.color = new Color32(0xff, 0xff, 0x00, 0x00);
                txtPlayer2Score.text = CoreController.Instance.GameManager.player2Score.ToString("00");
                txtPlayer2Score.DOColor(origColor, 1f);
            }
        }

        public IEnumerator Countdown()
        {
            txtCountdown.text = "Get Ready";
            txtCountdown.alpha = 1f;
            yield return new WaitForSeconds(1);
            txtCountdown.DOFade(0f, 0.9f);
            
            for (int i = 3; i > 0; i--)
            {
                ShowCount(i);
                yield return new WaitForSeconds(1);
            }
        }

        private void ShowCount(int i)
        {
            txtCountdown.text = i.ToString();
            txtCountdown.alpha = 1f;
            txtCountdown.DOFade(0f, 0.9f);
        }
        
        
    }
}
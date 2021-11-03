using System.Collections;
using Constants;
using Controllers;
using DG.Tweening;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public bool isGameActive;
        
        public int player1Score;
        public int player2Score;
        private int winningPlayer;
        
        public Ball ball;
        public Player player1;
        public Player player2;
        public Transform midLine;

        public ParticleSystem scoreEffect;

        private void Start()
        {
            ball.Hide();
            player1.Hide();
            player2.Hide();
            ToggleMidline(false, true);
        }

        private void Update()
        {
            if (isGameActive && Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause(true);
            }
        }

        public void StartNewGame()
        {
            player1Score = 0;
            player2Score = 0;
            CoreController.Instance.UiManager.UpdateScoreUi(1);
            CoreController.Instance.UiManager.UpdateScoreUi(2);
            
            isGameActive = true;
            
            player1.Show();
            player2.Show();
            
            ToggleMidline(true);
            
            player1.ResetState();
            player2.ResetState();
            
            ball.Hide();

            StartCoroutine(LaunchCountdown());
        }

        public IEnumerator LaunchCountdown()
        {
            CoreController.Instance.UiManager.StartCountdown();
            yield return new WaitForSeconds(4);
            ball.PrepForLaunch();
            ball.Launch();
        }

        public void PlayScoreEffect(Vector3 pos)
        {
            scoreEffect.transform.position = pos;
            scoreEffect.Play();
        }

        public void IncrementScore(int player)
        {
            if (player == 1)
            {
                player1Score++;
            }
            else
            {
                player2Score++;
            }
            
            CoreController.Instance.UiManager.UpdateScoreUi(player);
            
            if (IsGameOver())
            {
                player1.Hide();
                player2.Hide();
                ToggleMidline(false);
                
                CoreController.Instance.UiManager.ShowWin(player);
            }
            else
            {
                StartCoroutine(LaunchCountdown());
            }
        }
        
        private bool IsGameOver()
        {
            if (player1Score >= ProjectConstants.ScoreToWin)
            {
                winningPlayer = 1;
                isGameActive = false;
                return true;
            }
            if (player2Score >= ProjectConstants.ScoreToWin)
            {
                winningPlayer = 2;
                isGameActive = false;
                return true;
            }

            return false;
        }

        private void ToggleMidline(bool status, bool instant = false)
        {
            foreach (MeshRenderer midlineObj in midLine.GetComponentsInChildren<MeshRenderer>())
            {
                midlineObj.material.DOFade(status ? 1f : 0f, instant ? 0f : 1f);
            }
        }

        public void TogglePause(bool status)
        {
            isGameActive = !status;
            CoreController.Instance.UiManager.ShowMenu(status ? Menu.Pause : Menu.HUD);
            Time.timeScale = status ? 0f : 1f;
            CoreController.Instance.SoundManager.SetPauseStatus(status);
        }

        public void ExitToMenu()
        {
            isGameActive = false;
            Time.timeScale = 1f;
            CoreController.Instance.SoundManager.SetPauseStatus(false);
            
            player1.Hide();
            player2.Hide();
            ball.Freeze();
            ball.Hide();
            ToggleMidline(false);
            
            CoreController.Instance.UiManager.ShowMenu(Menu.Main);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}


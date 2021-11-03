using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Constants;
using Controllers;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private int winningPlayer;
        private Dictionary<int, int> PlayerScores = new Dictionary<int, int>
        {
            { 1, 0 },
            { 2, 0 }
        };

        public int Player1Score => PlayerScores[1];
        public int Player2Score => PlayerScores[2];

        private Ball ball;
        private Player player1;
        private Player player2;

        public void StartNewGame()
        {
            
        }

        public void IncrementScore(int player)
        {
            PlayerScores[player]++;
            CoreController.Instance.UiManager.UpdateScoreUi();
            if (IsGameOver())
            {
                
            }
        }
        
        private bool IsGameOver()
        {
            if (PlayerScores[1] >= ProjectConstants.ScoreToWin)
            {
                winningPlayer = 1;
                return true;
            }
            if (PlayerScores[2] >= ProjectConstants.ScoreToWin)
            {
                winningPlayer = 2;
                return true;
            }

            return false;
        }
    }
}


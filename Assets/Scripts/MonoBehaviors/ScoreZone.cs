using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int scoreForPlayer;
    
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Debug.Log($"Player {scoreForPlayer} Scores!");
            CoreController.Instance.GameManager.IncrementScore(scoreForPlayer);
            ball.Freeze();
            ball.transform.position = new Vector3(0, -20, 0);
        }
    }
}

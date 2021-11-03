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
            CoreController.Instance.GameManager.PlayScoreEffect(other.transform.position);
            
            CoreController.Instance.GameManager.IncrementScore(scoreForPlayer);
            ball.PlayBurst();
            ball.Hide();
        }
    }
}

using UnityEngine;

public class BallPickup : MonoBehaviour
{
    [SerializeField] private int ballValue = 1;
    private ScoreManager scoreManager; 
    public void SetScoreManager(ScoreManager manager)
    {
        scoreManager = manager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(ballValue);
            }

            Debug.Log("Player collected ball worth: " + ballValue);
            Destroy(gameObject);
        }
    }
}








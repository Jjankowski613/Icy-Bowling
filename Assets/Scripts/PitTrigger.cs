using UnityEngine;

public class PitTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Jeśli gameManager nie jest przypisany, spróbuj go znaleźć (zabezpieczenie)
            if(gameManager == null) gameManager = FindFirstObjectByType<GameManager>();
            if(gameManager != null) gameManager.BallEnteredPit();
        }
    }
}
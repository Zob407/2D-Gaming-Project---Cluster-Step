using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;
    public AudioClip collectSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Plays coin sound
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            // Increases score
            ScoreManager.score += coinValue;
            // Tracks number of the coins that are collected
            ScoreManager.coinsCollected++;
        
            // Every 10 coins, give an extra life
            if (ScoreManager.coinsCollected % 10 == 0)
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.GainLife();
                }
            }

            Destroy(gameObject);
        }
    }
}

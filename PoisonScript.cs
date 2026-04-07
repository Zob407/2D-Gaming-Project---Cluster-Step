using UnityEngine;

public class PoisonCluster : MonoBehaviour
{
    public AudioClip hitSound;
    public float destroyBelowY = -10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Plays hit sound if player hits poison
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }
            // Loses a life
            if (GameManager.instance != null)
            {
                GameManager.instance.LoseLife();
            }

            Destroy(gameObject);
        }
    }
    // Destroys poison cluster when it falls off the screen
    void Update()
    {
        if (transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }
}

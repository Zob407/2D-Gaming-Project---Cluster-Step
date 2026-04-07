using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Lives")]
    public int lives = 3;

    [Header("Audio")]
    public AudioClip extraLifeSound;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lives = 3;
    }

    // Calls when player is hit with a poison cluster
    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    // Calls when player collects 10 coins
    public void GainLife()
    {
        lives++;

        if (extraLifeSound != null)
        {
            AudioSource.PlayClipAtPoint(extraLifeSound, Camera.main.transform.position);
        }
    }
}

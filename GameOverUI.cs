using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text finalScoreText;

    void Start()
    {
        finalScoreText.text = "Final Score: " + ScoreManager.score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}

using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;

    void Update()
    {   // Shows the scores and lives
        scoreText.text = "Score: " + ScoreManager.score;
        livesText.text = "Lives: " + GameManager.instance.lives;
    }
}

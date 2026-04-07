using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int coinsCollected = 0;

    void Start()
    {
        // resets value when game starts or restarts.
        score = 0;
        coinsCollected = 0;
    }
}

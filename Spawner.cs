using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject poisonPrefab;

    public float coinSpawnInterval = 2f;
    public float poisonSpawnInterval = 3f;

    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f;

    private float coinTimer = 0f;
    private float poisonTimer = 0f;

    void Update()
    {
        coinTimer += Time.deltaTime;
        poisonTimer += Time.deltaTime;
        // Spawns coins
        if (coinTimer >= coinSpawnInterval)
        {
            SpawnCoin();
            coinTimer = 0f;
        }
        // Spawns poison 
        if (poisonTimer >= poisonSpawnInterval)
        {
            SpawnPoison();
            poisonTimer = 0f;

            // Slowly make the poison come faster
            if (poisonSpawnInterval > 0.8f)
            {
                poisonSpawnInterval -= 0.1f;
            }
        }
    }

    void SpawnCoin()
{
    Vector3 spawnPos = new Vector3(
        Random.Range(-8f, 8f),
        Random.Range(-2f, 4f),
        0f
    );

    Instantiate(coinPrefab, spawnPos, Quaternion.identity);
}

    void SpawnPoison()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), spawnY, 0f);
        Instantiate(poisonPrefab, spawnPos, Quaternion.identity);
    }
}

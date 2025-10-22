using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22f;
    private float spawnLimitXRight = 7f;
    private float spawnPosY = 30f;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    void Start()
    {
        // Spawn a random ball every few seconds
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    void SpawnRandomBall()
    {
        // Randomly choose a ball from the array
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Random X position within limits
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Spawn the random ball with its own rotation
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}

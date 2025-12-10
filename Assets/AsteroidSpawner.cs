using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject asteroidPrefab;
    public float spawnInterval = 2.0f;

    [Header("Spawn Area")]
    public float xRange = 8f;
    public float yMin = -2f;
    public float yMax = 4f;
    public float zDist = 25f;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= spawnInterval)
        {
            SpawnRock();
            _timer = 0;
        }
    }

    void SpawnRock()
    {
        float randomX = Random.Range(-xRange, xRange);
        float randomY = Random.Range(yMin, yMax);

        Vector3 spawnPos = new Vector3(randomX, randomY, zDist);

        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}
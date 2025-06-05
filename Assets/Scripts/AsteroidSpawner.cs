using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 3f;
    public float difficultyTimer = 0f;
    public float difficultyIncreaseTime = 15f;
    public float minSpawnInterval = 0.8f;
    public float speedIncreaseAmount = 0.3f;

    private float spawnTimer = 0f;
    private float baseMinSpeed = 1f;
    private float baseMaxSpeed = 3f;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnAsteroid();
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnAsteroid();
            spawnTimer = 0f;
        }

        // Every X seconds, increase difficulty
        if (difficultyTimer >= difficultyIncreaseTime)
        {
            baseMinSpeed += speedIncreaseAmount;
            baseMaxSpeed += speedIncreaseAmount;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - 0.3f);
            difficultyTimer = 0f;
        }
    }

    void SpawnAsteroid()
    {
        Vector2 pointA = GetOffscreenSpawnPoint();
        Vector2 pointB = GetOnscreenTargetPoint();

        GameObject asteroid = Instantiate(asteroidPrefab, pointA, Quaternion.identity);

        AsteroidScript mover = asteroid.GetComponent<AsteroidScript>();
        mover.pointA = pointA;
        mover.pointB = pointB;
        mover.moveSpeed = Random.Range(baseMinSpeed, baseMaxSpeed);
        mover.spinSpeed = Random.Range(-90f, 90f);
    }

    Vector2 GetOffscreenSpawnPoint()
    {
        int edge = Random.Range(0, 4);
        float x = 0f, y = 0f;

        switch (edge)
        {
            case 0: x = -10f; y = Random.Range(-5f, 5f); break;
            case 1: x = 10f;  y = Random.Range(-5f, 5f); break;
            case 2: x = Random.Range(-9f, 9f); y = 6f; break;
            case 3: x = Random.Range(-9f, 9f); y = -6f; break;
        }

        return new Vector2(x, y);
    }

    Vector2 GetOnscreenTargetPoint()
    {
        return new Vector2(
            Random.Range(-7f, 7f),
            Random.Range(-4f, 4f)
        );
    }
}

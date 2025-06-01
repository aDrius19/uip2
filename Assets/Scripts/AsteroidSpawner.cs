using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int numberOfAsteroids = 5;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float minSpin = -90f;
    public float maxSpin = 90f;

    void Start()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            SpawnAsteroid();
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
        mover.moveSpeed = Random.Range(minSpeed, maxSpeed);
        mover.spinSpeed = Random.Range(minSpin, maxSpin);
    }

    Vector2 GetOffscreenSpawnPoint()
    {
        int edge = Random.Range(0, 4);
        float x = 0f, y = 0f;

        switch (edge)
        {
            case 0: x = -10f; y = Random.Range(-5f, 5f); break;
            case 1: x = 10f;  y = Random.Range(-5f, 5f); break;
            case 2: x = Random.Range(-9f, 9f); y = 6f;  break;
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
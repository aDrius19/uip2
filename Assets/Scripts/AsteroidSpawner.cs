/* AsteroidSpawner.cs
 * This file contains the AsteroidSpawner class which controls how asteroids are initially spawned in the game.
 * It manages the spawn intervals, difficulty scaling, and the asteroid speed.
 */
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

     // Default total number of asteroids to be spawn in a game session
    public int asteroidsToSpawn = 20;
    public float spawnInterval = 3f;
    public float difficultyTimer = 0f;
    public float difficultyIncreaseTime = 15f;
    public float minSpawnInterval = 0.8f;
    public float speedIncreaseAmount = 0.3f;

    private int asteroidCounter;
    private float spawnTimer = 0f;
    private float baseMinSpeed = 1f;
    private float baseMaxSpeed = 3f;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// The game starts with 3 asteroids spawned.
    /// </summary>
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnAsteroid();
        }

        asteroidCounter = 3;
    }

    /// <summary>
    /// Update is called once per frame.
    /// This method determines when to spawn new asteroids based on the spawn interval and difficulty timer.
    /// </summary>
    void Update()
    {
        spawnTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        // Spawns a new asteroid if spawn timer has reached the spawn interval
        if (spawnTimer >= spawnInterval && asteroidCounter < asteroidsToSpawn)
        {
            SpawnAsteroid();
            spawnTimer = 0f;
        }

        // Increases the speed of asteroids and decreases the spawn interval to make the game more difficult
        if (difficultyTimer >= difficultyIncreaseTime)
        {
            baseMinSpeed += speedIncreaseAmount;
            baseMaxSpeed += speedIncreaseAmount;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - 0.3f);
            difficultyTimer = 0f;
        }
    }

    /// <summary>
    /// This method spawns a new asteroid offscreen and determines its direction and speed.
    /// </summary>
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

        asteroidCounter++;
    }

    /// <summary>
    /// This method spawns the asteroid in a position at the edge of the screen.
    /// </summary>
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

    /// <summary>
    /// This method returns a random point on the screen where the asteroid will move towards.
    /// </summary>
    Vector2 GetOnscreenTargetPoint()
    {
        return new Vector2(
            Random.Range(-7f, 7f),
            Random.Range(-4f, 4f)
        );
    }

    /// <summary>
    /// Public getter and setter of the asteroid count for other classes to use.
    /// </summary>
    public int AsteroidCounter
    {
        get
        {
            return asteroidCounter;
        }
        set
        {
            // include any checks you want to take place in here before setting the value
            asteroidCounter = value;
        }
    }
}

/* AsteroidScript.cs
 * This file contains the AsteroidScript class which controls asteroid movement, respawning, and interactions with other game objects.
 */
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Staring point of the asteroid
    public Vector2 pointA = new Vector2(-10f, 0f);

    // Ending point of the asteroid
    public Vector2 pointB = new Vector2(10f, 0f);

    // Asteroid movement speed
    public float moveSpeed = 2f;

    // Asteroid rotation speed
    public float spinSpeed = 90f;

    public AudioClip explosionSound;
    private Rigidbody2D rb;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method intializes the physics and movement of the asteroid.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetDirection();
    }

    /// <summary>
    /// This method sets the initial velocity and rotation of the asteroid from pointA to pointB.
    /// </summary>
    void SetDirection()
    {
        transform.position = pointA;

        Vector2 moveDirection = (pointB - pointA).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;
        rb.angularVelocity = spinSpeed;
    }

    /// <summary>
    /// Update is called once per frame
    /// This method checks if the asteroid is out of bounds. If it is, it respawns the asteroid in a new position.
    /// </summary>
    void Update()
    {
        if (transform.position.x < -11f || transform.position.x > 11f ||
            transform.position.y < -7f || transform.position.y > 7f)
        {
            Respawn();
        }
    }

    /// <summary>
    /// This method respawns the asteroid in a new position at the edge of the screen.
    /// It also chooses a new direction and speed for the asteroid.
    /// </summary>
    void Respawn()
    {
        int edge = Random.Range(0, 4);
        float x = 0f, y = 0f;

        switch (edge)
        {
            case 0: x = -10f; y = Random.Range(-5f, 5f); break;
            case 1: x = 10f; y = Random.Range(-5f, 5f); break;
            case 2: x = Random.Range(-9f, 9f); y = 6f; break;
            case 3: x = Random.Range(-9f, 9f); y = -6f; break;
        }

        pointA = new Vector2(x, y);
        pointB = new Vector2(
            Random.Range(-7f, 7f),
            Random.Range(-4f, 4f)
        );

        moveSpeed = Random.Range(1f, 3f);
        spinSpeed = Random.Range(-90f, 90f);

        SetDirection();
    }

    /// <summary>
    /// This method destroys the asteroid and plays an explosion sound when it collides with a bullet or a player.
    ///  It also updates the game score if a bullet hits the asteroid.
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameStats.instance.AddScore(10);
            Destroy(other.gameObject);

            PlayExplosionSound();
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            GameController.instance.GameOver();
            Destroy(other.gameObject);

            PlayExplosionSound();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This method plays an explosion sound effect when the asteroid is destroyed.
    /// </summary>
    void PlayExplosionSound()
    {
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, 2.0f);
        }
    }
}

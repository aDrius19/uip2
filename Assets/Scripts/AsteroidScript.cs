// AsteroidScript.cs
// This file contains the AsteroidScript class which controls asteroid movement, respawning, and interactions with other game objects.
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public Vector2 pointA = new Vector2(-10f, 0f);
    public Vector2 pointB = new Vector2(10f, 0f);
    public float moveSpeed = 2f;
    public float spinSpeed = 90f;

    public AudioClip explosionSound;
    private Rigidbody2D rb;

    // 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetDirection();
    }

    // This method sets the initial velocity and rotation of the asteroid.
    void SetDirection()
    {
        transform.position = pointA;

        Vector2 moveDirection = (pointB - pointA).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;
        rb.angularVelocity = spinSpeed;
    }

    void Update()
    {
        if (transform.position.x < -11f || transform.position.x > 11f ||
            transform.position.y < -7f || transform.position.y > 7f)
        {
            Respawn();
        }
    }

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

    void PlayExplosionSound()
    {
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, 2.0f);
        }
    }
}

using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public Vector2 pointA = new Vector2(-10f, 0f);
    public Vector2 pointB = new Vector2(10f, 0f);
    public float moveSpeed = 2f;
    public float spinSpeed = 90f;

    private Vector2 moveDirection;

    void Start()
    {
        SetDirection();
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);

        if (transform.position.x < -11f || transform.position.x > 11f ||
            transform.position.y < -7f || transform.position.y > 7f)
        {
            Respawn();
        }
    }

    void SetDirection()
    {
        transform.position = pointA;
        moveDirection = (pointB - pointA).normalized;
    }

    void Respawn()
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

        pointA = new Vector2(x, y);
        pointB = new Vector2(
            Random.Range(-7f, 7f),
            Random.Range(-4f, 4f)
        );

        moveSpeed = Random.Range(1f, 3f);
        spinSpeed = Random.Range(-90f, 90f);

        SetDirection();
    }
}
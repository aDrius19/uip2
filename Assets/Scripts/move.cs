using UnityEngine;

public class move : MonoBehaviour
{

    public float rotationSpeed = 100f; // Speed of rotation in degrees per second
    public float acceleration = 1f; // Acceleration in units per second squared
    public float maxSpeed = 5.0f; // Maximum speed in units per second
    public float frictionCoefficient = 0.5f; // Friction coefficient for deceleration

    public ParticleSystem exhaustParticles; // Reference to the exhaust particle system

    private Vector2 velocity = Vector2.zero; // Current velocity of the object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (exhaustParticles != null)
        {
            exhaustParticles.Stop(); // Ensure the exhaust is off at the start
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector2 forward = transform.up; // Get the forward direction of the object
            velocity += forward * acceleration * Time.deltaTime; // Increase velocity in the forward direction

            if (velocity.magnitude > maxSpeed) // Check if the velocity exceeds the maximum speed
            {
                velocity = velocity.normalized * maxSpeed; // Clamp the velocity to the maximum speed
            }

            // Play exhaust particles if they are not already playing
            if (exhaustParticles != null && !exhaustParticles.isPlaying)
            {
                exhaustParticles.Play();
            }
        }
        else
        {
            velocity = Vector2.Lerp(velocity, Vector2.zero, frictionCoefficient * Time.deltaTime); // Gradually reduce velocity when not accelerating

            // Disable exhaust particles
            if (exhaustParticles != null && exhaustParticles.isPlaying)
            {
                exhaustParticles.Stop();
            }
        }

        // Rotate the object based on arrow key input
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        // Apply velocity to the object's position
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}

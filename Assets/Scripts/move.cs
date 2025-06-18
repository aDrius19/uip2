/* move.cs
 * This file contains the move class which handles how the player moves in the game.
 */
using UnityEngine;

public class move : MonoBehaviour
{

    public float rotationSpeed = 100f; // Speed of rotation in degrees per second
    public float acceleration = 1f; // Acceleration in units per second squared
    public float maxSpeed = 5.0f; // Maximum speed in units per second
    public float frictionCoefficient = 0.5f; // Friction coefficient for deceleration

    private Vector2 velocity = Vector2.zero; // Current velocity of the object

    /// <summary>
    /// Update is called once per frame.
    /// This method handles user input for the ship's movement and rotation.
    /// </summary>
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
        }
        else
        {
            velocity = Vector2.Lerp(velocity, Vector2.zero, frictionCoefficient * Time.deltaTime); // Gradually reduce velocity when not accelerating
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

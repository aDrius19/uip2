/* ArrowMovement.cs
 * This file contains the ArrowMovement class, which controls the moving arrow that appears in the tutorial.
 */
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 2.5f;
    float startX;
    public float distance = 5;
    float addX;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method initialies the start X coordinate of the arrow.
    /// </summary>
    void Start()
    {
        startX = transform.position.x; // get the X coordinate of the Object
    }

    /// <summary>
    /// Update is called once per frame.
    /// This method updates the x position of the arrow to create a ping-pong effect.
    /// </summary>
    void Update()
    {
        addX = Mathf.PingPong(Time.time * speed, distance); // have the ping-pong animated effect of the arrow
        transform.position = new Vector2(startX + addX, transform.position.y); // move along the X-axis
    }
}

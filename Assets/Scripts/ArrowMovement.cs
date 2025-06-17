/* ArrowMovement.cs
 * 
 */
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 2.5f;
    float startX;
    public float distance = 5;
    float addX;

    void Start()
    {
        startX = transform.position.x; // get the X coordinate of the Object
    }

    void Update()
    {
        addX = Mathf.PingPong(Time.time * speed, distance); // have the ping-pong animated effect of the arrow
        transform.position = new Vector2(startX + addX, transform.position.y); // move along the X-axis
    }
}

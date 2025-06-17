/* ScreenWrap.cs
 * This file contains the ScreenWrap class which allows the ship to move off-screen and reappear on the opposite side.
 */
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float xMin, xMax, yMin, yMax;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method determines the screen boundaries based on the camera's orthographic size and aspect ratio.
    /// </summary>
    void Start()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        xMin = cam.transform.position.x - camWidth / 2f;
        xMax = cam.transform.position.x + camWidth / 2f;
        yMin = cam.transform.position.y - camHeight / 2f;
        yMax = cam.transform.position.y + camHeight / 2f;
    }

    /// <summary>
    /// Update is called once per frame.
    /// This method checks the ship's position and moves it to the opposite side if it moves out of bounds.
    /// </summary>
    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x > xMax)
            pos.x = xMin;
        else if (pos.x < xMin)
            pos.x = xMax;

        if (pos.y > yMax)
            pos.y = yMin;
        else if (pos.y < yMin)
            pos.y = yMax;

        transform.position = pos;
    }
}


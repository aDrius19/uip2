using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float xMin, xMax, yMin, yMax;

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


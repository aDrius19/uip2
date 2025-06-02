using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform leftShooter;
    public Transform rightShooter;
    private bool isShootingLeft = true;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform chosenFirePoint = isShootingLeft ? leftShooter : rightShooter;
            isShootingLeft = !isShootingLeft;

            GameObject bullet = Instantiate(bulletPrefab, chosenFirePoint.position, chosenFirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = chosenFirePoint.up * bulletSpeed;
        }
    }
}
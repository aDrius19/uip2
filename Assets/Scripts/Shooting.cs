/* Shooting.cs
 * This file contains the Shooting class, which controls how the bullets are shot from the ship and the sound effect played when the user shoots.
 */
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform leftShooter;
    public Transform rightShooter;
    private bool isShootingLeft = true;
    public float bulletSpeed = 10f;

    public AudioClip shootSound;
    private AudioSource audioSource;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method initializes the audio component for the player shooting sound effect.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// This method checks for player input to shoot bullets out of the left or right shooter.
    /// It also plays a shooting sound effect when the player shoots.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform chosenFirePoint = isShootingLeft ? leftShooter : rightShooter;
            isShootingLeft = !isShootingLeft;

            GameObject bullet = Instantiate(bulletPrefab, chosenFirePoint.position, chosenFirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = chosenFirePoint.up * bulletSpeed;


            if (shootSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSound, 0.2f);
            }
        }
    }
}

/* TutorialManager.cs
 * This file contains the TutorialManager class, which controls the tutorial for the game.
 */
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject player;
    public GameObject stats;
    public GameObject spawner;
    public float waitTime = 2f;

    private Shooting shot;
    private int popUpIndex;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method initializes player shooting, while hiding the stats and game object spawner.
    /// </summary>
    private void Start()
    {
        shot = player.GetComponent<Shooting>();
        shot.enabled = false;

        stats.SetActive(false);
        spawner.SetActive(false);
    }

    /// <summary>
    /// Update is called once per frame.
    /// This method manages the tutorial and uses player input to progress through the tutorial.
    /// </summary>
    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++) //load all the pop-up messages
        {
            if (i == popUpIndex) // equal to the scene, show it, otherwise no
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        switch (popUpIndex)
        {
            // Welcome message
            case 0:
                if (waitTime <= 0)
                {
                    popUpIndex++;
                    waitTime = 2.5f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;

            // Forward Movement
            case 1:
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    popUpIndex++;
                }
                break;

            // Perfect message
            case 2:
                if (waitTime <= 0)
                {
                    popUpIndex++;
                    waitTime = 2.5f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;

            // Rotation Movement
            case 3:
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    popUpIndex++;
                }
                break;

            // Perfect message
            case 4:
                if (waitTime <= 0)
                {
                    popUpIndex++;
                    waitTime = 2.5f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;

            // Settings panel
            case 5:
                if (Input.GetKey(KeyCode.Escape))
                {

                }

                if (Input.GetKey(KeyCode.BackQuote))
                {
                    popUpIndex++;
                }
                break;

            // Perfect message
            case 6:
                if (waitTime <= 0)
                {
                    popUpIndex++;
                    waitTime = 5f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;

            // Statistics panel
            case 7:
                if (waitTime <= 0)
                {
                    popUpIndex++;
                    waitTime = 2.5f;
                }
                else
                {
                    stats.SetActive(true);
                    waitTime -= Time.deltaTime;
                }
                break;

            // Perfect message
            case 8:
                if (waitTime <= 0)
                {
                    popUpIndex++;
                    waitTime = 10.0f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;

            // Space Panel where asterdois are spawnning
            case 9:
                if (waitTime <= 0)
                {
                    popUpIndex++;
                }
                else
                {
                    spawner.SetActive(true);
                    if (shot != null)
                    {
                        shot.enabled = true;
                    }

                    waitTime -= Time.deltaTime;
                }
                break;
        }
    }
}

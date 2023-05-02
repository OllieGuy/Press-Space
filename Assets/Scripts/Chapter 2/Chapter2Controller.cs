using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Chapter2Controller : MonoBehaviour
{
    public AudioManager am;
    public int level = 0;
    public GameObject player;
    public Camera platformCamera;
    public Camera walledCamera;
    public Camera fpCamera;
    private Rigidbody rb;
    private Player3rdPersonController p3c;
    private Player1stPersonMovement p1m;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        walledCamera.enabled = false;
        fpCamera.enabled = false;
        platformCamera.enabled = true;
        rb = player.GetComponent<Rigidbody>();
        p3c = player.GetComponent<Player3rdPersonController>();
        p1m = player.GetComponent<Player1stPersonMovement>();
    }

    void Update()
    {
        handleEvents();
    }

    void handleEvents()
    {
        if (p3c.jumpCount >= 25 && level == 0)
        {
            SceneManager.LoadScene("Job"); // REPLACE WITH SCENE
        }
        switch (level)
        {
            case 0:
                level++;
                break;
            case 1:
                if (player.transform.position.y < 80f)
                {
                    level++;
                    SpawnOnWalledPlatform();
                }
                break;
            case 2:
                if (player.transform.position.y < 50f)
                {
                    level++;
                    p3c.enabled = false;
                    p1m.enabled = true;
                    SpawnInRoom();
                }
                break;
            case 3:
                if (player.transform.position.y < 0f)
                {
                    level++;
                    SceneManager.LoadScene("Garden");
                }
                break;
            default:
                break;
        }
    }

    private void SpawnOnWalledPlatform()
    {
        platformCamera.enabled = false;
        platformCamera.GetComponent<AudioListener>().enabled = false;
        walledCamera.enabled = true;
        walledCamera.GetComponent<AudioListener>().enabled = true;
        player.transform.position = new Vector3(0f, 61.5f, 0f);
        rb.velocity = Vector3.zero;
    }
    private void SpawnInRoom()
    {
        walledCamera.enabled = false;
        walledCamera.GetComponent<AudioListener>().enabled = false;
        fpCamera.enabled = true;
        fpCamera.GetComponent<AudioListener>().enabled = true;
        fpCamera.GetComponent<FirstPersonCamera>().enabled = true;
        player.transform.position = new Vector3(0f, 2f, 0f);
        rb.velocity = Vector3.zero;
    }
}

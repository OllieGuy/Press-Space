using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code generated in part by ChatGPT
public class Player3rdPersonController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 1f;
    public float groundDistance = 0.4f;
    public Camera platformCamera;
    public Camera walledCamera;
    public GameObject chapter2Controller;

    private Rigidbody rb;
    private bool isGrounded;
    private Chapter2Controller c2c;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        walledCamera.enabled = false;
        platformCamera.enabled = true;
        c2c = chapter2Controller.GetComponent<Chapter2Controller>();
    }

    private void Update()
    {
        if (rb.transform.position.y == 101.5 || rb.transform.position.y == 51.5)
        { 
            isGrounded = true; 
        }
        else
        {
            isGrounded = false;
        }

        // Move the player horizontally
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Jump the player if they are grounded and the space key is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Check if the player has fallen off the platform
        if (transform.position.y < 80f && c2c.level == 0)
        {
            c2c.level++;
            SpawnOnWalledPlatform();
        }
        if (transform.position.y < 30f && c2c.level == 1)
        {
            c2c.level++;
            SpawnInGarden();
        }
    }

    private void SpawnOnWalledPlatform()
    {
        platformCamera.enabled = false;
        walledCamera.enabled = true;
        transform.position = new Vector3(0f, 61.5f, 0f);
        rb.velocity = Vector3.zero;
    }
    private void SpawnInGarden()
    {
        Debug.Log("asdfew");
    }
}

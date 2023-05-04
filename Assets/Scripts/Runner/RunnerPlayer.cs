using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayer : MonoBehaviour
{
    GroundAndObstacleSpawn gos;
    Rigidbody rb;
    Vector3 jumpHeight = new Vector3(0f,100f,0f);
    bool isGrounded = true;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("adtcc");
            rb.AddForce(jumpHeight);
            //isGrounded = false;
        }
    }
}

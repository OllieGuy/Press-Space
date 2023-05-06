using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayer : MonoBehaviour
{
    GroundAndObstacleSpawn gos;
    Rigidbody rb;
    Vector3 jumpHeight = new Vector3(0f,5000f,0f);
    bool isGrounded = true;
    bool pointWhenReachGround = false;
    public int score = 0;
    public GameObject counter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y > 0.15)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpHeight);
        }
        if (isGrounded && pointWhenReachGround)
        {
            score++;
            pointWhenReachGround = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "KeyCollider")
        {
            score = 0;
            pointWhenReachGround = false;
        }
        else if (col.gameObject.tag == "PointCollider" && !isGrounded)
        {
            pointWhenReachGround = true;
        }
    }
}

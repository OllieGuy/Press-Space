using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndDie : MonoBehaviour
{
    float timeTilDeath = 5f;
    float speed = 10f;
    public GameObject thisThing;
    void Start()
    {
        StartCoroutine(doTheThing());
    }

    void Update()
    {
        Vector3 shift = new Vector3(-(speed * Time.deltaTime), 0, 0);
        thisThing.transform.position += shift;
    }

    IEnumerator doTheThing()
    {
        yield return new WaitForSeconds(timeTilDeath);
        Destroy(thisThing);
    }
}

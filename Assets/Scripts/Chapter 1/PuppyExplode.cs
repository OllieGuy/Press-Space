using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyExplode : MonoBehaviour
{
    public GameObject ExplosionPlane;

    public void boom()
    {
        Debug.Log("attempt to boom");
        MeshRenderer MR = GetComponent<MeshRenderer>();
        MR.enabled = false;
        GameObject EP = Instantiate(ExplosionPlane, transform);
        StartCoroutine(Explosion(EP, MR));
    }

    IEnumerator Explosion(GameObject EP, MeshRenderer MR)
    {
        float timer = 0;
        timer += Time.deltaTime;
        bool complete = false;
        if (timer > 1f && !complete)
        {
            Destroy(EP);
            complete = true;
        }
        if (timer > 2f && complete)
        {
            MR.enabled = true;
            complete = false;
            timer = 0f;
        }
        yield return null;
    }
}

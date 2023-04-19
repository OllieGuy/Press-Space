using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3Controller : MonoBehaviour
{
    KeyController KC = new KeyController();
    public AudioManager am;
    public int level = 0;
    public ParticleSystem ps;
    public GameObject player;
    int unacceptableKeyCounter = 0;

    void Start()
    {
        StartCoroutine(footstepSounds());
        //firstCam.enabled = true;
    }

    void Update()
    {
        ps.transform.position = player.transform.position;
        handleInput();
        handleEvents();
    }

    void handleInput()
    {
        //if (Input.anyKeyDown)
        //{
        //    for (int i = 0; i < KC.acceptableKeys.Length; i++)
        //    {
        //        if (!Input.GetKeyDown(KC.acceptableKeys[i]))
        //        {
        //            unacceptableKeyCounter++;
        //            Debug.Log(unacceptableKeyCounter);
        //        }
        //    }
        //}
    }

    void handleEvents()
    {
        if (unacceptableKeyCounter == 5 && level == 0)
        {
            Debug.Log("asdf");
        }
    }

    IEnumerator footstepSounds()
    {
        float timer = 0;
        Vector3 prevPos = player.transform.position;
        while (true)
        {
            timer += Time.deltaTime;
            if (timer > 1f && Vector3.Distance(prevPos, player.transform.position) > 2)
            {
                am.play("test");
                prevPos = player.transform.position;
                timer -= 1f;
            }
            yield return null;
        }
    }
}

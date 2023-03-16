using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2Controller : MonoBehaviour
{
    KeyController KC = new KeyController();
    public AudioManager am;
    public Camera firstCam;
    public int level = 0;
    int unacceptableKeyCounter = 0;

    void Start()
    {
        //firstCam.enabled = true;
    }

    void Update()
    {
        handleInput();
        handleEvents();
    }

    void handleInput()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < KC.acceptableKeys.Length; i++)
            {
                if (!Input.GetKeyDown(KC.acceptableKeys[i]))
                {
                    unacceptableKeyCounter++;
                    Debug.Log(unacceptableKeyCounter);
                }
            }
        }
    }

    void handleEvents()
    {
        if (unacceptableKeyCounter == 5 && level == 0)
        {
            Debug.Log("asdf");
        }
    }
}

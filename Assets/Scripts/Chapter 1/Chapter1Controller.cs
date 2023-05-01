using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapter1Controller : MonoBehaviour
{
    KeyController KC = new KeyController();
    public GameObject PSBlack;
    public GameObject PSRed;
    public GameObject PFPuppyPlane;
    public GameObject PFPuppyExplode;
    PuppyExplode PE;
    public Image image;
    public AudioManager am;
    int acceptableKeyCounter = 0;
    int unacceptableKeyCounter = 0;
    int level = 0;

    void Start()
    {
        //KeyCode[] acceptableKeys = { KeyCode.Space };
        //KC = new KeyController(acceptableKeys);
        //am = FindObjectOfType<AudioManager>();
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
                    acceptableKeyCounter = 0;
                    Debug.Log(unacceptableKeyCounter);
                }
                else
                {
                    acceptableKeyCounter++;
                }
            }
        }
    }

    void handleEvents()
    {
        if (acceptableKeyCounter >= 25 && level < 3)
        {
            SceneManager.LoadScene("Job");
        }
        if (unacceptableKeyCounter == 5 && level == 0)
        {
            GameObject PS = Instantiate(PSBlack,image.transform);
            level++;
        }
        if (unacceptableKeyCounter == 10 && level == 1)
        {
            GameObject PS = Instantiate(PSRed, image.transform);
            level++;
        }
        if (unacceptableKeyCounter == 15 && level == 2)
        {
            GameObject PS = Instantiate(PFPuppyPlane, image.transform);
            PE = PS.GetComponent<PuppyExplode>();
            level++;
        }
        if (unacceptableKeyCounter == 16 && level == 3)
        {
            Debug.Log("boom boom");
            PE.boom();
            level++;
        }
        if (unacceptableKeyCounter == 25 && level == 4)
        {
            Debug.Log("attempt to audio");
            am.play("test");
            level++;
        }
    }
}

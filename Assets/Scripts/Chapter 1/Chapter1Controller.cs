using System;
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
    PuppyExplode PE;
    public Image image;
    public AudioManager am;
    int acceptableKeyCounter = 0;
    int unacceptableKeyCounter = 0;
    int level = 0;
    GameObject PS;
    bool enabledInput = true;

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
        if (Input.anyKeyDown && enabledInput)
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
            Instantiate(PSBlack,image.transform);
            StartCoroutine(disableInput(2.5f));
            level++;
        }
        if (unacceptableKeyCounter == 10 && level == 1)
        {
            Instantiate(PSRed, image.transform);
            StartCoroutine(disableInput(2.5f));
            level++;
        }
        if (unacceptableKeyCounter == 15 && level == 2)
        {
            am.play("C1_SFX_Bark");
            PS = Instantiate(PFPuppyPlane, image.transform);
            PE = PS.GetComponent<PuppyExplode>();
            StartCoroutine(disableInput(2.5f));
            level++;
        }
        if (unacceptableKeyCounter == 16 && level == 3)
        {
            StartCoroutine(disableInput(2.5f));
            PE.boom();
            level++;
        }
        if (unacceptableKeyCounter == 17 && level == 4)
        {
            StartCoroutine(disableInput(2.5f));
            PE.boom();
            level++;
        }
        if (unacceptableKeyCounter == 18 && level == 5)
        {
            StartCoroutine(disableInput(2.5f));
            Debug.Log(PS);
            PE.boom();
            Destroy(PS);
            StartCoroutine(puppyCleanUp());
            level++;
        }
        if (unacceptableKeyCounter == 25 && level == 6)
        {
            am.play("test");
            level++;
        }
    }
    IEnumerator puppyCleanUp()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(GameObject.Find("PuppyBoom(Clone)"));
    }
    IEnumerator disableInput(float time)
    {
        enabledInput = false;
        yield return new WaitForSeconds(time);
        enabledInput = true;
    }
}

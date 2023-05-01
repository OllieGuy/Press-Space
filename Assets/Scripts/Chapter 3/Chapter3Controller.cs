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
    public GameObject computer;
    public GameObject computerStand;
    FillScreen fsPlayer;
    int unacceptableKeyCounter = 0;

    void Start()
    {
        StartCoroutine(footstepSounds());
        StartCoroutine(computerSpawnIn());
        am.playOnLoop("C3_SFX_Void",0.7f);
        fsPlayer = player.GetComponent<FillScreen>();
    }

    void Update()
    {
        ps.transform.position = player.transform.position;
        handleInput();
        handleEvents();
    }

    void handleInput()
    {
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
                //am.play("test");
                prevPos = player.transform.position;
                timer -= 1f;
            }
            yield return null;
        }
    }

    IEnumerator computerSpawnIn()
    {
        yield return new WaitForSeconds(2);
        am.play("C3_SFX_Computer_On");
        yield return new WaitForSeconds(0.8f);
        computer.SetActive(true);
        yield return new WaitForSeconds(5f);
        am.play("C3_SFX_Computer_Off");
        yield return new WaitForSeconds(2f);
        computer.SetActive(false);
        computerStand.SetActive(false);
        fsPlayer.inRangeOfComputer = false;
    }
}

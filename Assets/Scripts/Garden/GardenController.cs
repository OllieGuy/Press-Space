using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GardenController : MonoBehaviour
{
    public AudioManager am;
    public GameObject player;

    void Start()
    {
        StartCoroutine(footstepSounds());
        am.playOnLoop("Gard_SFX_Ambient", 0.1f);
    }

    void Update()
    {
        handleEvents();
    }

    void handleEvents()
    {
        
    }

    IEnumerator footstepSounds()
    {
        float timer = 0;
        Vector3 prevPos = player.transform.position;
        bool lr = false;
        while (true)
        {
            timer += Time.deltaTime;
            if (timer > 0.3f && Vector3.Distance(prevPos, player.transform.position) > 2)
            {
                if (!lr)
                {
                    am.play("Gard_SFX_Grass_Walk");
                    lr = true;
                }
                else
                {
                    am.play("Gard_SFX_Grass_Walk_2");
                    lr = false;
                }
                prevPos = player.transform.position;
                timer -= 0.3f;
            }
            yield return null;
        }
    }
}

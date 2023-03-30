using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobController : MonoBehaviour
{
    public AudioManager am;

    void Start()
    {
        am.play("keyboardClicks");
    }

}

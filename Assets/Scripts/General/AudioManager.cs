using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public float play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        return s.source.clip.length;
    }
    public void playOnLoop(string name, float offset)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        Debug.Log("loop reached");
        StartCoroutine(looper(s, offset));
    }
    IEnumerator looper(Sound s, float offset)
    {
        float timer = 0;
        float lenthOfClip = s.source.clip.length;
        while (true)
        {
            if (timer > (lenthOfClip - offset))
            {
                Debug.Log("loooooop");
                s.source.Play();
                timer = 0;
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }
}

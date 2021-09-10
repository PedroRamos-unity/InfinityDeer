using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    public Sounds[] sounds;



    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.mixer;
        }

    }
    void Start()
    {
        instance = this;

    }

    public void PlaySound(string name,Vector3 pos)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Erro no audio");
            return;
        }
        AudioSource.PlayClipAtPoint(s.source.clip, pos);
        
    }

    public void StopSound(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Erro no audio");
            return;
        }
        s.source.Stop();
    }
}

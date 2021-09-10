using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;



    public void SetGeneralAudio(float volume)
    {
        audioMixer.SetFloat("mainVolume", volume);
    }

    public void SetSFXAudio(float volume)
    {
        audioMixer.SetFloat("sfxVolume", volume);
    }

    public void SetMusicAudio(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

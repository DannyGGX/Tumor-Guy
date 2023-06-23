using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [field: SerializeField] public Sound[] sounds { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        InitialiseSounds();

    }

    private void InitialiseSounds()
    {
        foreach(Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void PlaySound(SoundNames name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        sound.audioSource?.Play();
    }
}

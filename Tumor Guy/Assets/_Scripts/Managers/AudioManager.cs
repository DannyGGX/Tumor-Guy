using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [field: SerializeField] public Sound[] Sounds { get; set; }

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
        foreach(Sound sound in Sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.Clip;
            sound.audioSource.volume = sound.Volume;
            sound.audioSource.pitch = sound.Pitch;
            sound.audioSource.loop = sound.Loop;
        }
    }

    public void PlaySound(SoundNames name)
    {
        Sound sound = Array.Find(Sounds, s => s.Name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        sound.audioSource?.Play();
    }

    public void PlaySound(SoundNames name, Vector3 position)
    {

    }
}

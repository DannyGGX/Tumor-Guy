using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixer mixer;
    private const string PARAMETER_NAME = "MasterVolume";
    [field: SerializeField, Range(0.0001f, 1f)] public float VolumeSliderValue { get; set; } = 0.8f;
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
        InitialiseMixerVolume();
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
            sound.audioSource.outputAudioMixerGroup = mixer.outputAudioMixerGroup;
        }
    }
    private void InitialiseMixerVolume()
    {
        mixer.SetFloat(PARAMETER_NAME, ToLogarithmicMixerValue(VolumeSliderValue));
    }
    private float ToLogarithmicMixerValue(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    private Sound GetSound(SoundNames name)
    {
        Sound sound = Array.Find(Sounds, s => s.Name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return null;
        }
        return sound;
    }

    public void PlaySoundEffect(SoundNames name)
    {
        Sound sound = GetSound(name);
        if (sound != null)
            sound.audioSource.Play();
    }
    public void PlaySound3D(SoundNames name, Vector3 position)
    {

    }

    public void PlayMusic(SoundNames name)
    {
        Sound sound = Array.Find(Sounds, s => s.Name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }

        if (sound.audioSource.isPlaying)
        {
            return;
        }
        else
        {
            sound.audioSource.Play();
        }
    }

    public void StopSound(SoundNames name)
    {
        Sound sound = Array.Find(Sounds, s => s.Name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }

        sound.audioSource.Stop();

        //if (sound.audioSource.isPlaying)
        //{
        //    sound.audioSource.Stop();
        //}
    }

    public void StopAllSounds()
    {
        foreach(var sound in Sounds)
        {
            sound.audioSource?.Stop();
        }
    }


    public bool IsMenuMusicPlaying()
    {
        Sound sound = Array.Find(Sounds, s => s.Name == SoundNames.MenuMusic);
        if (sound == null)
        {
            return false;
        }
        return sound.audioSource.isPlaying;
    }

}

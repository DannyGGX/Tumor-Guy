using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;
    private const string PARAMETER_NAME = "MasterVolume";

    private void OnEnable()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            SetAudioLevel(v);
        });
    }
    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    private void Start()
    {
        slider.value = AudioManager.Instance.VolumeSliderValue;

    }

    public void SetAudioLevel(float value)
    {
        mixer.SetFloat(PARAMETER_NAME, ToLogarithmicMixerValue(value));
        AudioManager.Instance.VolumeSliderValue = value;
    }

    private float ToLogarithmicMixerValue(float value)
    {
        return Mathf.Log10(value) * 20;
    }
}

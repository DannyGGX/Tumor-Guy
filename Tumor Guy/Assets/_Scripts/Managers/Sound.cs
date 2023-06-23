using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public SoundNames name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;

    [Range (0.3f, 3f)]
    public float pitch = 1;

    public bool loop = false;

    [Range (0f, 1f)]
    public float SpatialBlend = 0.8f;

    [HideInInspector] public AudioSource audioSource;
}

public enum SoundNames
{
    FloorFootsteps,
    RubbleFootsteps,
    TumorThump,
    Dash,
    Hurt,
    KnockOut,
    WakeUp,
    TumorExplode,
    HeavyBreathing,

    PlayerVoiceIntro,
    PlayerVoiceBodies,
    PlayerVoiceRobotEncounter,
    PlayerVoiceDash,
    PlayerVoiceLockedDoor,
    PlayerVoiceFirstWakeUp,
    PlayerVoiceLastWakeUp,
    PlayerVoiceFindScientist,

    LaserShot,
    LaserImpact,
    RobotDamaged,

    ButtonDraw,
    ButtonClick,

    Ambience,
    MenuMusic,
}

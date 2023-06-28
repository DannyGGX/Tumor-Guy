using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public SoundNames Name;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume = 1;

    [Range (0.3f, 3f)]
    public float Pitch = 1;

    public bool Loop = false;

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

    LaserShot,
    LaserImpact,
    RobotDamaged,
    RobotDestroy,
    RobotTurretTurn,
    RobotTurretHalt,

    UnlockDoor,
    OpenDoor,
    WrongKey,

    BeepPositive,
    BeepNegative,
    BlastDoorOpen,

    PickUpPaper,
    PickUpKey,
    PickUpKeycard,

    ButtonDraw,
    ButtonClick,

    Ambience,
    MenuMusic,

    PlayerVoiceIntro,
    PlayerVoiceBodies,
    PlayerVoiceRobotEncounter,
    PlayerVoiceDash,
    PlayerVoiceLockedDoor,
    PlayerVoiceFirstWakeUp,
    PlayerVoiceLastWakeUp,
    PlayerVoiceFindScientist,

    ScientistVoiceTape,
    ScientistVoiceEnd,
}

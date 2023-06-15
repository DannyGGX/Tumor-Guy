using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// find how to serialize class
public class PlayerStats
{
    private const int PLAYER_LIVES = 5;

    public float[] TumorBallScaleSizes { get; set; } = new float[PLAYER_LIVES];
    public float[] TumorBallDistances { get; set; } = new float[PLAYER_LIVES];
    [field: SerializeField] public GameObject[] TumorDesigns { get; set; } = new GameObject[PLAYER_LIVES];

    public float[] MovementSpeeds { get; set; } = new float[PLAYER_LIVES];
    public float[] RotationSpeeds { get; private set; }

    public float[] DashSpeeds { get; private set; }
    public float[] DashDurations { get; private set; }
    public float[] DashCooldowns { get; private set; }

    public float[] AttackDamages { get; private set; } = new float[PLAYER_LIVES];

    public float[] GetStats(int playerLifeIndex)
    {

        return new float[PLAYER_LIVES];
    }
}

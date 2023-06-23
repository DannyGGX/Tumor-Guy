using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    private const int PLAYER_LIVES = 5;
    public const int AMOUNT_FLOAT_STATS = 6;
    public float[] TumorBallScaleSizes { get; set; } = new float[PLAYER_LIVES];
    public float[] TumorBallDistances { get; set; } = new float[PLAYER_LIVES];
    [field: SerializeField] public GameObject[] TumorDesigns { get; set; } = new GameObject[PLAYER_LIVES];

    public float[] MovementSpeeds { get; set; } = new float[PLAYER_LIVES];
    public float[] RotationSpeeds { get; private set; }

    public float[] DashSpeeds { get; private set; }
    public float[] DashDurations { get; private set; }
    public float[] DashCooldowns { get; private set; }

    public float[] AttackDamages { get; private set; } = new float[PLAYER_LIVES];

    public enum FloatStatsOrder
    {
        MovementSpeeds,
        RotationSpeeds,
        DashSpeeds,
        DashDurations,
        DashCoolDowns,
        AttackDamages,
    }

    public float[] GetStats(int playerLifeIndex)
    {
        float[] stats = new float[AMOUNT_FLOAT_STATS];
        stats[0] = MovementSpeeds[playerLifeIndex];
        stats[1] = RotationSpeeds[playerLifeIndex];
        stats[2] = DashSpeeds[playerLifeIndex];
        stats[3] = DashDurations[playerLifeIndex];
        stats[4] = DashCooldowns[playerLifeIndex];
        stats[5] = AttackDamages[playerLifeIndex];
        return stats;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotNoTurret : Enemy
{


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Attack()
    {
        base.Attack();
        StartCoroutine(nameof(BurstFire));
    }
}

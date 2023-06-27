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
        Vision();
    }

    private void FixedUpdate()
    {
        if (PlayerInSight)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        base.Attack();
    }
}

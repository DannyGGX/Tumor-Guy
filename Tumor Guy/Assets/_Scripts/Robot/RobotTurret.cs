using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTurret : RobotWithTurret
{
    [Space]
    [SerializeField] private float rotationSpeed = 10f;


    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        Vision();
    }
    public override void Vision()
    {
        HitInfoRight = Physics2D.Raycast(transform.position, transform.up, visionDistance, bulletLayer);

        if (HitInfoRight.collider != null)
        {
            Debug.DrawLine(transform.position, HitInfoRight.point, Color.red);

            if (HitInfoRight.collider.CompareTag("Player") || HitInfoRight.collider.CompareTag("Tumor"))
            {
                Debug.Log("Shoot player");
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up * visionDistance, Color.green);
        }
    }

}

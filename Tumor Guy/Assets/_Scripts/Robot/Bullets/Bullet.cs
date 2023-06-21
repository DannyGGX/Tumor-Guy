using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float BulletDamage = 80;
    [SerializeField] private AudioClip ShootSound;

    private void Start()
    {
        //play shoot sound
    }

}

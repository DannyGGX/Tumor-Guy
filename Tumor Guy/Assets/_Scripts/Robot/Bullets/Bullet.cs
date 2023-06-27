using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 80;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float maxActiveDuration = 2.5f;
    [SerializeField] private AudioClip ShootSound;
    [Space]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask bulletLevelObjects;

    private void OnEnable()
    {
        Invoke(nameof(Disable), maxActiveDuration);
    }
    private void Start()
    {
        //play shoot sound
        //rb.velocity = transform.up * bulletSpeed;
    }

    private void Update()
    {
        rb.velocity = transform.up * bulletSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == bulletLevelObjects || collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        //if (collision.gameObject.CompareTag("Enemy"))
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Disable));
    }
}

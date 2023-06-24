using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public float CurrentHealth = 100;
    [SerializeField] private GameObject DestroyedRobot;
    [field: SerializeField] public Transform FirePoint; // Also for vision
    [field: SerializeField] public int BulletsPerBurst = 3;
    [field: SerializeField] public float BurstFireRate = 0.2f; // time between bullets fired in a burst
    [field: SerializeField] public float TimeBetweenBursts = 0.8f;
    // Shooting angle deviation
    [field: SerializeField] public float MinAngleDeviation = -2; // in degrees
    [field: SerializeField] public float MaxAngleDeviation = 2;
    [field: Space]
    [field: Header("Vision")]
    [field: SerializeField] public float visionDistance = 6;
    [field: SerializeField] public LayerMask bulletLayer;
    public bool PlayerInSight = false;

    private Coroutine BurstFireRoutine = null;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (PlayerInSight)
        {
            Attack();
        }
    }
    public virtual void Attack()
    {
        if (BurstFireRoutine == null)
        {
            BurstFireRoutine = StartCoroutine(nameof(BurstFire));
        }
    }
    public IEnumerator BurstFire()
    {
        WaitForSeconds fireWait = new WaitForSeconds(BurstFireRate);

        for (int i = 0; i < BulletsPerBurst - 1; i++)
        {
            FireBullet();
            yield return fireWait;
        }
        FireBullet();
        yield return new WaitForSeconds(TimeBetweenBursts);
        //BurstFireRoutine = null;
    }

    private void FireBullet()
    {
        GameObject bullet = BulletPool.Instance.GetBulletFromPool();
        bullet.transform.position = FirePoint.position;
        bullet.transform.rotation = FirePoint.rotation;
        bullet.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        //Instantiate(DestroyedRobot, transform.position, Quaternion.identity);
    }

    
    private void OnTriggerEnter2D(Collider2D collision) // For dying from getting shot by other robots
    {
        
    }
}

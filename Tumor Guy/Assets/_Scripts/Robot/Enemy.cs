using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [field: SerializeField] public float CurrentHealth = 100;
    [SerializeField] private GameObject DestroyedRobot;
    [Space]
    [Header("Shooting")]
    [HideInInspector] public RaycastHit2D HitInfoRight;
    [HideInInspector] public RaycastHit2D HitInfoLeft;
    [field: SerializeField] public Transform FirePoint;
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
    [HideInInspector] public bool PlayerInSight = false;
    [field: SerializeField] public Transform VisionLeftPoint;
    [field: SerializeField] public Transform VisionRightPoint;

    private Coroutine BurstFireRoutine = null;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public virtual void Vision()
    {
        HitInfoRight = Physics2D.Raycast(VisionRightPoint.position, transform.up, visionDistance, bulletLayer);
        Collider2D hitCollider = GetObjectInVision();

        if (hitCollider != null)
        {
            //Debug.DrawLine(transform.position, HitInfoRight.point, Color.red);

            if (hitCollider.CompareTag("Player") || hitCollider.CompareTag("Tumor"))
            {
                PlayerInSight = true;
            }
            else
            {
                PlayerInSight = false;
            }
        }
        else
        {
            PlayerInSight = false;
            //Debug.DrawLine(transform.position, transform.position + transform.up * visionDistance, Color.green);
        }
    }

    private Collider2D GetObjectInVision()
    {
        RaycastHit2D hitInfoRight = Physics2D.Raycast(VisionRightPoint.position, transform.up, visionDistance, bulletLayer);
        RaycastHit2D hitInfoLeft = Physics2D.Raycast(VisionLeftPoint.position, transform.up, visionDistance, bulletLayer);
        int coinFlip = Random.Range(0, 2);
        if(coinFlip == 0)
        {
            if (hitInfoRight == true)
            {
                return hitInfoRight.collider;
            }
            if (hitInfoLeft == true)
            {
                return hitInfoLeft.collider;
            }
        }
        else
        {
            if (hitInfoLeft == true)
            {
                return hitInfoLeft.collider;
            }
            if (hitInfoRight == true)
            {
                return hitInfoRight.collider;
            }
        }
        return null;
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
        BurstFireRoutine = null;
    }

    private void FireBullet()
    {
        GameObject bullet = BulletPool.Instance.GetBulletFromPool();
        bullet.transform.position = FirePoint.position;
        bullet.transform.rotation = FirePoint.rotation;
        bullet.SetActive(true);
        AudioManager.Instance.PlaySoundEffect(SoundNames.LaserShot);
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

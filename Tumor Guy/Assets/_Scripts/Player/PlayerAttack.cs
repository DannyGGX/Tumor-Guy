using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float minVelocity = 3;
    [SerializeField] private float maxVelocity = 10;
    [SerializeField] private float damageMultiplier = 6;

    private float velocityMagnitude;
    private const float BASE_MIN_DAMAGE = 1;
    private const float BASE_MAX_DAMAGE = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            velocityMagnitude = collision.relativeVelocity.magnitude;
            Debug.Log($"Tumor velocity: {velocityMagnitude}");
            if(velocityMagnitude < minVelocity)
                return;

            Enemy enemyHit = collision.gameObject.GetComponent<Enemy>();
            enemyHit.TakeDamage(CalculateVelocityDamage());
            AudioManager.Instance.PlaySound(SoundNames.RobotDamaged);
        }
    }

    private float CalculateVelocityDamage()
    {
        float mappedDamage = Mathf.Lerp(BASE_MIN_DAMAGE, BASE_MAX_DAMAGE, Mathf.InverseLerp(minVelocity, maxVelocity, velocityMagnitude));
        mappedDamage *= damageMultiplier;
        Debug.Log("Damage: " + mappedDamage);
        return mappedDamage;
    }
}

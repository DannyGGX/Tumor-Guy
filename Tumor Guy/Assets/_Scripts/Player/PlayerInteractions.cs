using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteractions : MonoBehaviour
{
    public static event Action OnPlayerDie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnPlayerDie?.Invoke();
        }
    }

}

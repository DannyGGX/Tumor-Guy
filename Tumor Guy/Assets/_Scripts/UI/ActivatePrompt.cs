using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePrompt : MonoBehaviour
{
    [SerializeField] private GameObject prompt;

    private void Awake()
    {
        prompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerDash"))
        {
            prompt.SetActive(true);
        }
    }
    
}

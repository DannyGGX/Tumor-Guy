using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceLine : MonoBehaviour
{
    [SerializeField] private SoundNames voiceLineName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerDash"))
        {
            AudioManager.Instance.PlaySound(voiceLineName);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopVoice : MonoBehaviour
{
    [SerializeField] private SoundNames voiceLineToStop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerDash"))
        {
            if (AudioManager.Instance.IsSoundPlaying(voiceLineToStop))
            {
                AudioManager.Instance.StopSound(voiceLineToStop);
            }

        }
    }
}

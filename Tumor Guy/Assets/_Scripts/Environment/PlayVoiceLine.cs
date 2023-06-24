using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceLine : MonoBehaviour
{
    [SerializeField] private SoundNames voiceLineName;
    [SerializeField] private float waitToPlay = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerDash"))
        {
            Invoke(nameof(PlayAudio), waitToPlay);
        }
    }

    private void PlayAudio()
    {
        AudioManager.Instance.PlaySound(voiceLineName);
        Destroy(gameObject);
    }
}

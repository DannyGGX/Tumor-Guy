using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private string playerDashTag = "PlayerDash";
    [SerializeField] private SpriteRenderer sprite;
    //[SerializeField] private Color startColor;
    [SerializeField] private float fadeDuration = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag(playerDashTag))
        {
            StartCoroutine(FadeOutSprite(fadeDuration));
        }
    }

    private IEnumerator FadeOutSprite(float duration)
    {
        float time = 0;
        Color startColor = new Color(0.25f, 0.25f, 0.25f, 1);
        Color targetColor = new Color(0, 0, 0, 0);

        while (time < duration)
        {
            sprite.color = Color.Lerp(startColor, targetColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = targetColor;
        Destroy(gameObject);
    }
}

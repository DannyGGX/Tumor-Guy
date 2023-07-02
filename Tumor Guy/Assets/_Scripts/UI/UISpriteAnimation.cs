using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteAnimation : MonoBehaviour
{

    [SerializeField] private Image image;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float animationSpeed = 0.2f;

    private int currentSpriteIndex;
    private Coroutine animationCoroutine;
    private bool IsDone;

    private void OnEnable()
    {
        PlayAnimation();
    }

    private void OnDisable()
    {
        StopAnimation();
    }

    public void PlayAnimation()
    {
        IsDone = false;
        StartCoroutine(AnimationCycle());
    }

    public void StopAnimation()
    {
        IsDone = true;
        StopCoroutine(AnimationCycle());
    }
    IEnumerator AnimationCycle()
    {
        yield return new WaitForSeconds(animationSpeed);
        if (currentSpriteIndex >= sprites.Length)
        {
            currentSpriteIndex = 0;
        }
        image.sprite = sprites[currentSpriteIndex];
        currentSpriteIndex += 1;
        if (IsDone == false)
            animationCoroutine = StartCoroutine(AnimationCycle());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool isSceneTransition;
    [SerializeField] private int SceneNumberOnOtherSide;
    [SerializeField] private float timeToGoThroughDoor = 2;
    [Space]
    [SerializeField] private bool isLocked;
    [SerializeField] private KeyIDs requiredKey;
    //[SerializeField] private float unlockDuration;
    [Space]
    [SerializeField] private bool openTowardsUpDirection = true;
    [SerializeField] private float openForceMultiplier = 100f;
    [SerializeField] private Rigidbody2D rigidbody2;

    void Awake()
    {
        rigidbody2.bodyType = RigidbodyType2D.Static;
    }

    private void OnMouseDown()
    {
        if (isLocked)
        {
            
        }
        else
        {
            rigidbody2.bodyType = RigidbodyType2D.Dynamic;
            AudioManager.Instance.PlaySoundEffect(SoundNames.OpenDoor);

            if (openTowardsUpDirection)
            {
                rigidbody2.AddForce(Vector2.up * openForceMultiplier);
            }
            else
            {
                rigidbody2.AddForce(Vector2.down * openForceMultiplier);
            }

            if (isSceneTransition)
            {
                Invoke(nameof(GoToLevel), timeToGoThroughDoor);
            }
        }
    }

    private void CheckForCorrectKey()
    {
        if (GameManager.Instance.FoundKeys.Contains(requiredKey))
        {

        }
        else
        {
            // Play lock struggle sound
        }
    }

    private void GoToLevel()
    {
        GameManager.Instance.GoToLevel(SceneNumberOnOtherSide);
    }
}

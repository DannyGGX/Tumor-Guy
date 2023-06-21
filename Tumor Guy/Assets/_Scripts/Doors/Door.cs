using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int SceneNumberOnOtherSide;
    [SerializeField] private bool isLocked;
    [SerializeField] private KeyIDs requiredKey;
    [SerializeField] private float timeToGoThroughDoor = 2;

    void Awake()
    {
        
    }

    private void CheckForCorrectKey()
    {
        if (GameManager.Instance.FoundKeys.Contains(requiredKey))
        {
            // Play open sound, then go to next scene
            Invoke(nameof(GoToLevel), timeToGoThroughDoor);
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

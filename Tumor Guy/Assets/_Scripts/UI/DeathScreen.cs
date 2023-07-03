using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject UIObject;

    private void Awake()
    {
        UIObject.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerInteractions.OnPlayerDie += PlayerDie;
    }
    private void OnDisable()
    {
        PlayerInteractions.OnPlayerDie -= PlayerDie;
    }

    private void PlayerDie()
    {
        GameManager.Instance.SetPauseState(true);
        UIObject.SetActive(true);
    }

    public void RetryGame()
    {
        GameManager.Instance.SetPauseState(false);
        GameManager.Instance.StartGame();
    }

    public void ToMainMenu()
    {
        GameManager.Instance.SetPauseState(false);
        GameManager.Instance.StartMainMenu();
    }
}

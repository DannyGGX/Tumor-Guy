using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject CreditsScreen;

    public void BackButtonClicked()
    {
        CreditsScreen.SetActive(false);
        MainScreen.SetActive(true);
    }

    public void GoToCredits()
    {
        CreditsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

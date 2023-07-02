using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameManager.Instance.InspectionScreenActive)
            {
                GameManager.Instance.CloseInspectionScreen();
            }
            else
            {
                ChangePauseScreenState(GameManager.Instance.IsPaused);
            }
        }
    }

    private void ChangePauseScreenState(bool pauseState)
    {
        if (pauseState)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        menuObject.SetActive(true);
        GameManager.Instance.SetPauseState(true);
    }

    public void ResumeGame()
    {
        menuObject.SetActive(false);
        GameManager.Instance.SetPauseState(false);
    }

    public void GoToMainMenu()
    {
        GameManager.Instance.SetPauseState(false);
        GameManager.Instance.StartMainMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsPaused { get; private set; } = false;
    public bool ControlsEnabled { get; private set; } = true;
    public bool RobotsEnabled { get; private set; } = true;

    [Header("Scene Management")]
    [SerializeField] private int currentScene;
    [field: Space]
    [field: Header("Player")]
    public int KnockOutAmount { get; private set; } = 0;
    public List<Key> FoundKeys { get; private set; }
    


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        
    }


    public void PauseToggle()
    {
        if (IsPaused)
            Unpause();
        else
            Pause();
    }
    private void Pause()
    {
        Time.timeScale = 0;
        IsPaused = true;
        ControlsEnabled = false;
    }
    private void Unpause()
    {
        Time.timeScale = 1;
        IsPaused = false;
        ControlsEnabled = true;
    }
}

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
    [SerializeField] private int level1SceneIndex;
    [field: Space]
    [field: Header("Player")]
    public int KnockOutAmount { get; private set; } = 0;
    public List<KeyIDs> FoundKeys { get; private set; }

    public bool InspectionScreenActive = false;
    


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
    private void Start()
    {
        StartLevel1();
        
    }

    public void CloseInspectionScreen()
    {
        InspectionScreen.Instance.CloseInspectionScreen();
    }
    public void GoToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void StartLevel1()
    {
        AudioManager.Instance.PlaySound(SoundNames.Ambience);
        FoundKeys = new List<KeyIDs>();
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

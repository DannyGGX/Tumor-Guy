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
    [SerializeField] private int MainMenuSceneIndex;
    [SerializeField] private int level1SceneIndex;
    [SerializeField] private int level2SceneIndex;
    [field: Space]
    [field: Header("Player")]
    [SerializeField] private Transform playerLocation;
    public int KnockOutAmount { get; private set; } = 0;
    public List<KeyIDs> FoundKeys { get; private set; }

    [HideInInspector] public bool InspectionScreenActive = false;
    


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
        StartMainMenu();
        
    }

    public void CloseInspectionScreen()
    {
        InspectionScreen.Instance.CloseInspectionScreen();
    }

    public void KnockOut()
    {

    }

    public void WakeUp()
    {

    }

    public void GoToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void StartMainMenu()
    {
        if(AudioManager.Instance.IsMenuMusicPlaying() == false)
        {
            AudioManager.Instance.PlayMusic(SoundNames.MenuMusic);
        }
        SceneManager.LoadScene(MainMenuSceneIndex);
    }

    public void StartGame()
    {
        AudioManager.Instance.StopSound(SoundNames.MenuMusic);
        StartLevel1();
    }

    public void StartLevel1()
    {
        AudioManager.Instance.PlaySoundEffect(SoundNames.Ambience);
        FoundKeys = new List<KeyIDs>();
        SceneManager.LoadScene(level1SceneIndex);
    }


    public void PauseToggle()
    {
        if (IsPaused)
            Unpause();
        else
            Pause();
    }
    public void SetPauseState(bool state)
    {
        if (state)
            Pause();
        else
            Unpause();
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

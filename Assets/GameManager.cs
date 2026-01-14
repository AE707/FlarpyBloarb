using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }
        // UI Reference
    public GameObject pausePanel;
    public GameObject startScreenPanel;
    public GameObject settingsMenuPanel;
    private bool hasGameStarted = false;
    private GameState stateBeforeSettings;

    // Game state enum
    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver
    }

    // Current game state
    private GameState currentState;
    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            if (currentState != value)
            {
                GameState previousState = currentState;
                currentState = value;
                OnGameStateChanged?.Invoke(previousState, currentState);
            }
        }
    }

    // Event for state changes
    public event Action<GameState, GameState> OnGameStateChanged;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Register scene load callback
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize game in Menu state
        if (!hasGameStarted)
        {
            ShowStartScreen();
                    }
            }
        // Update is called once per frame
    private void Update()
    {
        // Handle pause/resume with ESC key
        if (Input.GetKeyDown(KeyCode.Escape) && Instance != null)
        {
            // Don't handle ESC if settings menu is open
            if (settingsMenuPanel != null && settingsMenuPanel.activeSelf)
             {
                 HideSettingsMenu();
                return;
            }

            if (Instance.IsPlaying())
            {
                Instance.PauseGame();
            }
            else if (Instance.IsPaused())
            {
                Instance.ResumeGame();
            }
        }
        
        
                // Handle settings menu with M key
        if (Input.GetKeyDown(KeyCode.M) && Instance != null)
        {
            if (settingsMenuPanel != null && settingsMenuPanel.activeSelf)
            {
                HideSettingsMenu();
                
            }
            else if (Instance.IsPlaying() || Instance.IsPaused())
            {
                
                ShowSettingsMenu();
            }
        }
    }

    // Pause the game
    public void PauseGame()
    {
        if (CurrentState == GameState.Playing)
        {
                   // Close settings menu if open
        if (settingsMenuPanel != null && settingsMenuPanel.activeSelf)
        {
            settingsMenuPanel.SetActive(false);
        }
            CurrentState = GameState.Paused;
            Time.timeScale = 0f;  // Freeze game time
            if (pausePanel != null) pausePanel.SetActive(true);
        }
    }

    // Resume the game
    public void ResumeGame()
    {
        if (CurrentState == GameState.Paused)
        {
            CurrentState = GameState.Playing;
            Time.timeScale = 1f;  // Resume game time
            if (pausePanel != null) pausePanel.SetActive(false);
        }
    }

    // Start the game
    public void StartGame()
    {
            hasGameStarted = true;
            HideStartScreen();
        CurrentState = GameState.Playing;
        Time.timeScale = 1f; // Ensure time is running
    }

        // Show the menu
    public void ShowStartScreen()
    {
        CurrentState = GameState.Menu;
        Time.timeScale = 0f;  // Freeze game time
        if (startScreenPanel != null) startScreenPanel.SetActive(true);
    }

    // Hide the menu
    public void HideStartScreen()
    {
        if (startScreenPanel != null) startScreenPanel.SetActive(false);
    }

    // End the game
    public void GameOver()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.GameOver;
                    Time.timeScale = 0f; // Freeze game time
        }
    }

    // Check if game is in specific state
    public bool IsPlaying()
    {
        return CurrentState == GameState.Playing;
    }

    public bool IsGameOver()
    {
        return CurrentState == GameState.GameOver;
    }

    public bool IsPaused()
    {
        return CurrentState == GameState.Paused;
    }


    // Show settings menu
    public void ShowSettingsMenu()
    {
        if (settingsMenuPanel != null)
        {
            stateBeforeSettings = CurrentState; // Remember current state
            settingsMenuPanel.SetActive(true);
            Time.timeScale = 0f; // Freeze game
        }
    }

    // Hide settings menu
    public void HideSettingsMenu()
    {
        if (settingsMenuPanel != null)
        {
            settingsMenuPanel.SetActive(false);
            // Only restore timeScale if we were actually playing
            if (stateBeforeSettings == GameState.Playing)
            {
                Time.timeScale = 1f;
            }
        }
    }

        // Hide pause panel
    public void HidePausePanel()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }


private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
{
    // Find Canvas first
    Canvas canvas = FindObjectOfType<Canvas>(true); // true = include inactive
    
    if (canvas != null)
    {
        // Search within Canvas children
        Transform pauseTransform = canvas.transform.Find("PausePanel");
        Transform startTransform = canvas.transform.Find("StartScreenPanel");
        Transform settingsTransform = canvas.transform.Find("SettingsMenuPanel");
        
        if (pauseTransform != null) pausePanel = pauseTransform.gameObject;
        if (startTransform != null) startScreenPanel = startTransform.gameObject;
        if (settingsTransform != null) settingsMenuPanel = settingsTransform.gameObject;
    }
    
    // Reset game started flag if needed
    if (!hasGameStarted)
    {
        ShowStartScreen();
    }
}
    

}




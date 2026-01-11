using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

        // UI Reference
    public GameObject pausePanel;
        public GameObject menuPanel;

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
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize game in Menu state
        ShowMenu();
        // Update is called once per frame
    private void Update()
    {
        // Handle pause/resume with ESC key
        if (Input.GetKeyDown(KeyCode.Escape) && Instance != null)
        {
            if (Instance.IsPlaying())
            {
                Instance.PauseGame();
            }
            else if (Instance.IsPaused())
            {
                Instance.ResumeGame();
            }
        }
    }

    // Pause the game
    public void PauseGame()
    {
        if (CurrentState == GameState.Playing)
        {
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
            HideMenu();
        CurrentState = GameState.Playing;
        Time.timeScale = 1f; // Ensure time is running
    }

    // End the game
    public void GameOver()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.GameOver;
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
}

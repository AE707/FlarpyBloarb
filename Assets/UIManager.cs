using UnityEngine;

public class UIManager : MonoBehaviour
{

    
    // Called by Resume button in Pause Panel
    public void OnResumeButtonClick()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResumeGame();
        }
    }

    // Called by Restart button in Pause Panel
    public void OnRestartButtonClick()
    {
        if (GameManager.Instance != null)
        {
            // Find LogicScript and call RestartGame
            LogicScript logic = FindObjectOfType<LogicScript>();
            if (logic != null)
            {
                logic.RestartGame();
            }
        }
    }

    // Called by Main Menu button in Pause Panel
    public void OnMainMenuButtonClick()
    {
        if (GameManager.Instance != null)
        {
            // Hide pause panel first
            GameManager.Instance.HidePausePanel();
            // Resume time first
            Time.timeScale = 1f;
            // Load main menu scene or show start screen
            GameManager.Instance.ShowSettingsMenu();
        }
    }

    // Called by Close button (X) in Settings Panel
    public void OnCloseSettingsButtonClick()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.HideSettingsMenu();
        }
    }

    // Called by Start Game button in Start Screen Panel
    public void OnStartGameButtonClick()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }
    }

    // Optional: Called by Pause button if you have one in-game
    public void OnPauseButtonClick()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PauseGame();
        }
    }
}

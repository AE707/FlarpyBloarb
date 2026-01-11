using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
   public int PlayerScore;
   public Text scoreText;
   public GameObject GameOverScreen;

    [ContextMenu("Increase Score ")]
   public void addScore(int scoreToAdd)
    {
        if (scoreToAdd > 0)
                {
            PlayerScore += scoreToAdd;
            scoreText.text = PlayerScore.ToString();
    }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

}

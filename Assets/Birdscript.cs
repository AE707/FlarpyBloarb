using UnityEngine;

public class Birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
     public LogicScript logic;
     public bool birdIsAlive = true;

    public GameObject pausePanel;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
                if (logicObject != null)
                        {
                                    logic = logicObject.GetComponent<LogicScript>();
                                            }
    }

    // Update is called once per frame
    void Update()
    {
        
                // Handle pause/resume with ESC key
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance != null)
        {
            if (GameManager.Instance.IsPlaying())
            {
                GameManager.Instance.PauseGame();
                                if (pausePanel != null) pausePanel.SetActive(true);
            }
            else if (GameManager.Instance.IsPaused())
            {
                GameManager.Instance.ResumeGame();
                                if (pausePanel != null) pausePanel.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && GameManager.Instance != null && GameManager.Instance.IsPlaying())        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}

using UnityEngine;

public class Birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
     public LogicScript logic;
     public bool birdIsAlive = true;


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
    // Check if bird is out of bounds
    if (birdIsAlive && (transform.position.y > 20 || transform.position.y < -20))
    {
        birdIsAlive = false;
        myRigidbody.linearVelocity = Vector2.zero;
        myRigidbody.gravityScale = 0f;
        logic.GameOver();
        return;
    }
    
    if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && GameManager.Instance != null && GameManager.Instance.IsPlaying() && !GameManager.Instance.IsPaused()) 
        myRigidbody.linearVelocity = Vector2.up * flapStrength;
    }       
    

    void OnCollisionEnter2D(Collision2D collision)
    {
    if (birdIsAlive)
        {
            birdIsAlive = false;
            myRigidbody.linearVelocity = Vector2.zero; // Stop movement
            myRigidbody.gravityScale = 0f; // Disable gravity
            logic.GameOver();
        }
    }

}

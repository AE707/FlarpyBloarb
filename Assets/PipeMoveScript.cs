using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    public float baseMoveSpeed = 5f; // Starting speed
    public float maxMoveSpeed = 15f; // Maximum speed cap
    public float speedIncreasePerPoint = 0.2f; // Speed increase per score point
    public float currentMoveSpeed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get current score from LogicScript
        LogicScript logic = FindObjectOfType<LogicScript>();
            if (logic != null)
                {
                    // Calculate speed based on score
                    currentMoveSpeed = baseMoveSpeed + (logic.PlayerScore * speedIncreasePerPoint);
                    // Cap at max speed
                    currentMoveSpeed = Mathf.Min(currentMoveSpeed, maxMoveSpeed);
                }
            else
                 {
                    currentMoveSpeed = baseMoveSpeed;
                }

        Vector3 pos = transform.position;
                pos += Vector3.left * currentMoveSpeed * Time.deltaTime;
                        transform.position = pos;
                        
        if (pos.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float desiredPipeSpacing = 20f; // Desired distance between pipes
    private float currentSpawnRate;

    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Only spawn pipes when game is playing
        if (GameManager.Instance == null || !GameManager.Instance.IsPlaying())
        {
            return;
        }
        
        // Calculate spawn rate based on current pipe speed
        PipeMoveScript pipeMover = FindObjectOfType<PipeMoveScript>();
            if (pipeMover != null)
                {
                    float currentSpeed = pipeMover.currentMoveSpeed; // Use actual speed
                    currentSpawnRate = desiredPipeSpacing / currentSpeed;
                    // Add minimum spawn rate to prevent too-fast spawning
                    currentSpawnRate = Mathf.Max(currentSpawnRate, 2.8f); 
                }
            else
                {
                    currentSpawnRate = spawnRate;
                }

            if (timer < currentSpawnRate)
                {
                    timer = timer + Time.deltaTime;
                }
            else
                {
                    spawnPipe();
                    timer = 0;
                }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }
}

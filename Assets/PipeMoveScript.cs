using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
                pos += Vector3.left * moveSpeed * Time.deltaTime;
                        transform.position = pos;
                        
        if (pos.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}

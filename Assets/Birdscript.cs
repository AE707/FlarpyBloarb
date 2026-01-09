using UnityEngine;

public class Birdscript : MonoBehaviour
{
    public Rigidbody2D myRegidbody;
     public float flapStrength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ==true)
        {
            myRegidbody.linearVelocity = Vector2.up * 10;
        }
       
    }
}

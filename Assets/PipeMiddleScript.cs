using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logic; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
        if (logicObject != null)
                {
            logic = logicObject.GetComponent<LogicScript>();
        }
            }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 )
        {
            logic.addScore(1);
        }
    }
}

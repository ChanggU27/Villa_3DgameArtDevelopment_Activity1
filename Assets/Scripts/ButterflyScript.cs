using UnityEngine;

public class ButterflyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.linearVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (logic.gameHasStarted && !logic.isGameOver)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                myRigidbody.linearVelocity = Vector2.up * flapStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        myRigidbody.linearVelocity = Vector2.zero; 
    }
}